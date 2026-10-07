using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;
using NAudio.Wave;

namespace _2611_WIN_B3.Game
{
    public enum SoundEffect
    {
        Click,
        ClueDiscovered,
        TimelineConnected,
        Victory,
        Failure,
        Notification,
        AppOpen
    }

    /// <summary>
    /// Audio Engine chuyên nghiệp tích hợp NAudio.
    /// Chạy song song trên Worker Thread nền (Dedicated Background Audio Thread),
    /// Zero Lag / Non-blocking Queue cho UI.
    /// Giải mã và phát âm thanh nhạc nền MP3/WAV chuẩn xác 100% qua DirectSound/WaveOut.
    /// </summary>
    public class AudioManager
    {
        private static readonly Lazy<AudioManager> _instance = new Lazy<AudioManager>(() => new AudioManager());
        public static AudioManager Instance => _instance.Value;

        private readonly ConcurrentQueue<Action> _audioTaskQueue = new();
        private readonly AutoResetEvent _hasTaskEvent = new(false);
        private readonly Thread _audioWorkerThread;
        private volatile bool _isRunning = true;

        private readonly Dictionary<SoundEffect, string> _soundFileMap;
        private readonly Dictionary<string, string> _verifiedSoundPaths = new(StringComparer.OrdinalIgnoreCase);

        // NAudio BGM Engine
        private IWavePlayer? _bgmWaveOut;
        private AudioFileReader? _bgmReader;
        private LoopStream? _bgmLoopStream;

        private float _bgmVolume = 0.25f; // Giảm nhạc nền xuống 25% (êm dịu, không lấn át)
        private float _sfxVolume = 1.40f; // Âm lượng hiệu ứng thông thường 140%
        private float _clueVolume = 2.50f; // Tăng âm lượng phát hiện manh mối clue.wav lên 250%

        public float BgmVolume
        {
            get => _bgmVolume;
            set
            {
                _bgmVolume = Math.Clamp(value, 0.0f, 1.0f);
                if (_bgmReader != null)
                {
                    _bgmReader.Volume = _bgmVolume;
                }
            }
        }

        public float SfxVolume
        {
            get => _sfxVolume;
            set => _sfxVolume = Math.Max(0.0f, value);
        }

        public float ClueVolume
        {
            get => _clueVolume;
            set => _clueVolume = Math.Max(0.0f, value);
        }

        private bool _isMuted = false;
        public bool IsMuted
        {
            get => _isMuted;
            set
            {
                _isMuted = value;
                EnqueueCommand(() =>
                {
                    if (_isMuted)
                    {
                        PauseBgmInternal();
                    }
                    else
                    {
                        ResumeBgmInternal();
                    }
                });
            }
        }

        public bool IsBgmPlaying { get; private set; } = false;
        private string _soundsDir;

        public AudioManager()
        {
            _soundsDir = ResolveSoundsDirectory();

            _soundFileMap = new Dictionary<SoundEffect, string>
            {
                { SoundEffect.Click, "click.wav" },
                { SoundEffect.ClueDiscovered, "clue.wav" },
                { SoundEffect.TimelineConnected, "connect.wav" },
                { SoundEffect.Victory, "win.wav" },
                { SoundEffect.Failure, "fail.wav" },
                { SoundEffect.Notification, "notify.wav" },
                { SoundEffect.AppOpen, "open.wav" }
            };

            // Khởi chạy Worker Thread riêng
            _audioWorkerThread = new Thread(AudioEngineLoop)
            {
                Name = "AudioEngine_WorkerThread",
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal
            };
            _audioWorkerThread.Start();

            ScanSoundFiles();
        }

        private string ResolveSoundsDirectory()
        {
            var candidates = new[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds"),
                Path.Combine(Directory.GetCurrentDirectory(), "Sounds"),
                @"D:\ltw\2611_WIN_B3\Sounds"
            };

            foreach (var dir in candidates)
            {
                if (Directory.Exists(dir)) return dir;
            }

            try
            {
                string target = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
                Directory.CreateDirectory(target);
                return target;
            }
            catch
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public string GetSoundsDirectory() => _soundsDir;

        public void ScanSoundFiles()
        {
            try
            {
                _verifiedSoundPaths.Clear();
                if (!Directory.Exists(_soundsDir)) return;

                var files = Directory.GetFiles(_soundsDir, "*.*");
                foreach (var f in files)
                {
                    string name = Path.GetFileName(f);
                    if (new FileInfo(f).Length > 0)
                    {
                        _verifiedSoundPaths[name] = f;
                    }
                }
            }
            catch { }
        }

        private void AudioEngineLoop()
        {
            while (_isRunning)
            {
                try
                {
                    _hasTaskEvent.WaitOne(100);

                    while (_audioTaskQueue.TryDequeue(out var task))
                    {
                        try
                        {
                            task();
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }

        private void EnqueueCommand(Action cmd)
        {
            _audioTaskQueue.Enqueue(cmd);
            _hasTaskEvent.Set();
        }

        #region Background Music (BGM Engine - NAudio Native Stream Loop)

        public void StartBgm()
        {
            EnqueueCommand(() =>
            {
                if (_isMuted) return;
                StartBgmInternal();
            });
        }

        private void StartBgmInternal()
        {
            try
            {
                if (_bgmWaveOut != null && _bgmWaveOut.PlaybackState == PlaybackState.Playing)
                {
                    return;
                }

                if (_bgmWaveOut != null && _bgmWaveOut.PlaybackState == PlaybackState.Paused)
                {
                    _bgmWaveOut.Play();
                    IsBgmPlaying = true;
                    return;
                }

                StopBgmInternal();

                string[] bgmCandidates = { "bgm.mp3", "bgm.wav", "music.mp3", "music.wav", "theme.mp3", "theme.wav" };
                string? targetFile = null;

                foreach (var name in bgmCandidates)
                {
                    if (_verifiedSoundPaths.TryGetValue(name, out var fullPath) && File.Exists(fullPath))
                    {
                        targetFile = fullPath;
                        break;
                    }
                    string fallbackPath = Path.Combine(_soundsDir, name);
                    if (File.Exists(fallbackPath) && new FileInfo(fallbackPath).Length > 0)
                    {
                        targetFile = fallbackPath;
                        break;
                    }
                }

                if (targetFile == null) return;

                // Sử dụng AudioFileReader của NAudio giải mã trực tiếp cả MP3 và WAV chuẩn xác
                var reader = new AudioFileReader(targetFile)
                {
                    Volume = _bgmVolume // Âm lượng 35%
                };
                _bgmReader = reader;

                // Bọc qua LoopStream để tự động lặp vô tận
                _bgmLoopStream = new LoopStream(reader);

                _bgmWaveOut = new WaveOut();
                _bgmWaveOut.Init(_bgmLoopStream);
                _bgmWaveOut.Play();
                IsBgmPlaying = true;
            }
            catch { }
        }

        public void StopBgm()
        {
            EnqueueCommand(StopBgmInternal);
        }

        public void PauseBgm()
        {
            EnqueueCommand(PauseBgmInternal);
        }

        public void ResumeBgm()
        {
            EnqueueCommand(ResumeBgmInternal);
        }

        private void StopBgmInternal()
        {
            try
            {
                if (_bgmWaveOut != null)
                {
                    _bgmWaveOut.Stop();
                    _bgmWaveOut.Dispose();
                    _bgmWaveOut = null;
                }
                if (_bgmLoopStream != null)
                {
                    _bgmLoopStream.Dispose();
                    _bgmLoopStream = null;
                }
                if (_bgmReader != null)
                {
                    _bgmReader.Dispose();
                    _bgmReader = null;
                }
                IsBgmPlaying = false;
            }
            catch { }
        }

        private void PauseBgmInternal()
        {
            try
            {
                _bgmWaveOut?.Pause();
            }
            catch { }
        }

        private void ResumeBgmInternal()
        {
            try
            {
                if (_bgmWaveOut != null && _bgmWaveOut.PlaybackState == PlaybackState.Paused)
                {
                    _bgmWaveOut.Play();
                }
                else
                {
                    StartBgmInternal();
                }
            }
            catch { }
        }

        #endregion

        #region Sound Effects (SFX Engine - NAudio Fire-and-Forget, 0ms Delay)

        public void Play(SoundEffect effect)
        {
            if (_isMuted) return;

            // Đẩy vào hàng đợi xử lý ngầm (UI thread trả về 0ms ngay lập tức)
            EnqueueCommand(() =>
            {
                try
                {
                    if (_soundFileMap.TryGetValue(effect, out var fileName))
                    {
                        string? targetPath = null;
                        if (_verifiedSoundPaths.TryGetValue(fileName, out var p) && File.Exists(p))
                        {
                            targetPath = p;
                        }
                        else
                        {
                            string diskPath = Path.Combine(_soundsDir, fileName);
                            if (File.Exists(diskPath) && new FileInfo(diskPath).Length > 0)
                            {
                                targetPath = diskPath;
                                _verifiedSoundPaths[fileName] = diskPath;
                            }
                        }

                        if (targetPath != null)
                        {
                            // Nếu là manh mối (clue.wav / ClueDiscovered) -> áp dụng âm lượng 200% (_clueVolume)
                            float volume = (effect == SoundEffect.ClueDiscovered || fileName.Equals("clue.wav", StringComparison.OrdinalIgnoreCase))
                                ? _clueVolume
                                : _sfxVolume;

                            // Phát độc lập bằng NAudio WaveOut, tự giải phóng khi xong
                            PlaySfxViaNaudio(targetPath, volume);
                            return;
                        }
                    }

                    // Fallback sang âm thanh hệ thống nếu chưa có file
                    PlayFallback(effect);
                }
                catch
                {
                    try { PlayFallback(effect); } catch { }
                }
            });
        }

        private void PlaySfxViaNaudio(string filePath, float? customVolume = null)
        {
            try
            {
                var reader = new AudioFileReader(filePath)
                {
                    Volume = customVolume ?? _sfxVolume
                };
                var waveOut = new WaveOut();
                waveOut.Init(reader);
                waveOut.PlaybackStopped += (s, e) =>
                {
                    try
                    {
                        waveOut.Dispose();
                        reader.Dispose();
                    }
                    catch { }
                };
                waveOut.Play();
            }
            catch
            {
                try
                {
                    using var sp = new SoundPlayer(filePath);
                    sp.Play();
                }
                catch { }
            }
        }

        private void PlayFallback(SoundEffect effect)
        {
            switch (effect)
            {
                case SoundEffect.ClueDiscovered:
                    SystemSounds.Asterisk.Play();
                    break;
                case SoundEffect.TimelineConnected:
                    SystemSounds.Beep.Play();
                    break;
                case SoundEffect.Victory:
                    SystemSounds.Asterisk.Play();
                    break;
                case SoundEffect.Failure:
                    SystemSounds.Hand.Play();
                    break;
                case SoundEffect.Notification:
                    SystemSounds.Exclamation.Play();
                    break;
                case SoundEffect.Click:
                case SoundEffect.AppOpen:
                default:
                    SystemSounds.Beep.Play();
                    break;
            }
        }

        #endregion

        public void Shutdown()
        {
            _isRunning = false;
            _hasTaskEvent.Set();
            StopBgm();
        }
    }

    /// <summary>
    /// Stream lặp vô tận (Looping Stream) chuẩn cho NAudio
    /// </summary>
    public class LoopStream : WaveStream
    {
        private readonly WaveStream _sourceStream;

        public LoopStream(WaveStream sourceStream)
        {
            _sourceStream = sourceStream;
            EnableLooping = true;
        }

        public bool EnableLooping { get; set; }

        public override WaveFormat WaveFormat => _sourceStream.WaveFormat;

        public override long Length => _sourceStream.Length;

        public override long Position
        {
            get => _sourceStream.Position;
            set => _sourceStream.Position = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = _sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (_sourceStream.Position == 0 || !EnableLooping)
                    {
                        break;
                    }
                    // Quay lại đầu tệp để lặp lại
                    _sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _sourceStream.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
