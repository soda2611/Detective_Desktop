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

        // Quản lý các WaveOut và Reader đang phát SFX để dọn dẹp triệt để
        private readonly List<(IWavePlayer waveOut, IDisposable reader)> _activeSfxPlayers = new();
        private readonly object _sfxLock = new();

        private float _bgmVolume = 0.30f; // Giảm nhạc nền xuống 30% (êm dịu, không lấn át)
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

            EnsureDefaultSoundFiles();
            ScanSoundFiles();
        }

        private string ResolveSoundsDirectory()
        {
            var candidates = new[]
            {
                "Sounds",
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Sounds"),
                Path.Combine(Directory.GetCurrentDirectory(), "Sounds")
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

        private void EnsureDefaultSoundFiles()
        {
            var soundDirs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (!string.IsNullOrEmpty(_soundsDir)) soundDirs.Add(_soundsDir);
            soundDirs.Add("Sounds");
            soundDirs.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds"));
            soundDirs.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Sounds"));
            soundDirs.Add(Path.Combine(Directory.GetCurrentDirectory(), "Sounds"));

            var generators = new Dictionary<string, Func<short[]>>(StringComparer.OrdinalIgnoreCase)
            {
                { "click.wav", GenerateClickSamples },
                { "notify.wav", GenerateNotifySamples },
                { "connect.wav", GenerateConnectSamples },
                { "win.wav", GenerateWinSamples },
                { "fail.wav", GenerateFailSamples }
            };

            foreach (var dir in soundDirs)
            {
                try
                {
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    foreach (var kvp in generators)
                    {
                        string filePath = Path.Combine(dir, kvp.Key);
                        if (!File.Exists(filePath) || new FileInfo(filePath).Length < 100)
                        {
                            short[] samples = kvp.Value();
                            WriteWavFile(filePath, samples, 44100);
                        }
                    }
                }
                catch { }
            }
        }

        private static short[] GenerateClickSamples()
        {
            const int sampleRate = 44100;
            int totalSamples = sampleRate * 40 / 1000;
            short[] samples = new short[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                double t = (double)i / sampleRate;
                double freq = 1400.0 - (1000.0 * (t / 0.04));
                double env = (t < 0.002) ? (t / 0.002) : Math.Exp(-(t - 0.002) / 0.008);
                double val = Math.Sin(2.0 * Math.PI * freq * t) * env;
                samples[i] = (short)Math.Clamp(val * 24000.0, -32767.0, 32767.0);
            }
            return samples;
        }

        private static short[] GenerateNotifySamples()
        {
            const int sampleRate = 44100;
            int totalSamples = sampleRate * 280 / 1000;
            short[] samples = new short[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                double t = (double)i / sampleRate;
                double val;
                if (t < 0.10)
                {
                    double localT = t;
                    double env = (localT < 0.005) ? (localT / 0.005) : Math.Exp(-localT / 0.04);
                    val = (Math.Sin(2.0 * Math.PI * 587.33 * t) + 0.25 * Math.Sin(2.0 * Math.PI * 1174.66 * t)) * env;
                }
                else
                {
                    double localT = t - 0.10;
                    double env = (localT < 0.005) ? (localT / 0.005) : Math.Exp(-localT / 0.07);
                    val = (Math.Sin(2.0 * Math.PI * 880.0 * t) + 0.20 * Math.Sin(2.0 * Math.PI * 1760.0 * t)) * env;
                }
                samples[i] = (short)Math.Clamp(val * 22000.0, -32767.0, 32767.0);
            }
            return samples;
        }

        private static short[] GenerateConnectSamples()
        {
            const int sampleRate = 44100;
            int totalSamples = sampleRate * 420 / 1000;
            short[] samples = new short[totalSamples];
            double[] notes = { 523.25, 659.25, 783.99, 1046.50 };
            double step = 0.090;

            for (int i = 0; i < totalSamples; i++)
            {
                double t = (double)i / sampleRate;
                int noteIdx = Math.Min(notes.Length - 1, (int)(t / step));
                double localT = t - (noteIdx * step);
                double freq = notes[noteIdx];
                double env = (localT < 0.004) ? (localT / 0.004) : Math.Exp(-localT / 0.08);
                double val = (Math.Sin(2.0 * Math.PI * freq * t) + 0.3 * Math.Sin(2.0 * Math.PI * (freq * 2.0) * t)) * env;
                samples[i] = (short)Math.Clamp(val * 24000.0, -32767.0, 32767.0);
            }
            return samples;
        }

        private static short[] GenerateWinSamples()
        {
            const int sampleRate = 44100;
            int totalSamples = sampleRate * 850 / 1000;
            short[] samples = new short[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                double t = (double)i / sampleRate;
                double val;
                if (t < 0.08)
                {
                    double env = (t < 0.005) ? (t / 0.005) : Math.Exp(-t / 0.04);
                    val = Math.Sin(2.0 * Math.PI * 523.25 * t) * env;
                }
                else if (t < 0.16)
                {
                    double localT = t - 0.08;
                    double env = (localT < 0.005) ? (localT / 0.005) : Math.Exp(-localT / 0.04);
                    val = Math.Sin(2.0 * Math.PI * 659.25 * t) * env;
                }
                else if (t < 0.24)
                {
                    double localT = t - 0.16;
                    double env = (localT < 0.005) ? (localT / 0.005) : Math.Exp(-localT / 0.04);
                    val = Math.Sin(2.0 * Math.PI * 783.99 * t) * env;
                }
                else
                {
                    double localT = t - 0.24;
                    double env = (localT < 0.008) ? (localT / 0.008) : Math.Exp(-localT / 0.20);
                    val = (Math.Sin(2.0 * Math.PI * 523.25 * t) * 0.30 +
                           Math.Sin(2.0 * Math.PI * 659.25 * t) * 0.25 +
                           Math.Sin(2.0 * Math.PI * 783.99 * t) * 0.25 +
                           Math.Sin(2.0 * Math.PI * 1046.50 * t) * 0.20) * env;
                }
                samples[i] = (short)Math.Clamp(val * 24000.0, -32767.0, 32767.0);
            }
            return samples;
        }

        private static short[] GenerateFailSamples()
        {
            const int sampleRate = 44100;
            int totalSamples = sampleRate * 360 / 1000;
            short[] samples = new short[totalSamples];

            for (int i = 0; i < totalSamples; i++)
            {
                double t = (double)i / sampleRate;
                double val;
                if (t < 0.16)
                {
                    double env = (t < 0.005) ? (t / 0.005) : Math.Exp(-t / 0.08);
                    val = (Math.Sin(2.0 * Math.PI * 349.23 * t) + 0.25 * Math.Sin(2.0 * Math.PI * 698.46 * t)) * env;
                }
                else
                {
                    double localT = t - 0.16;
                    double env = (localT < 0.005) ? (localT / 0.005) : Math.Exp(-localT / 0.10);
                    val = (Math.Sin(2.0 * Math.PI * 293.66 * t) + 0.25 * Math.Sin(2.0 * Math.PI * 587.33 * t)) * env;
                }
                samples[i] = (short)Math.Clamp(val * 22000.0, -32767.0, 32767.0);
            }
            return samples;
        }

        private static void WriteWavFile(string filePath, short[] samples, int sampleRate)
        {
            int byteRate = sampleRate * 1 * 2;
            int dataChunkSize = samples.Length * 2;
            int fileSize = 36 + dataChunkSize;

            using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
            using var bw = new BinaryWriter(fs);

            // RIFF header
            bw.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));
            bw.Write(fileSize);
            bw.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"));

            // fmt subchunk
            bw.Write(System.Text.Encoding.ASCII.GetBytes("fmt "));
            bw.Write(16);
            bw.Write((short)1); // PCM
            bw.Write((short)1); // Mono
            bw.Write(sampleRate);
            bw.Write(byteRate);
            bw.Write((short)2); // BlockAlign
            bw.Write((short)16); // BitsPerSample

            // data subchunk
            bw.Write(System.Text.Encoding.ASCII.GetBytes("data"));
            bw.Write(dataChunkSize);

            for (int i = 0; i < samples.Length; i++)
            {
                bw.Write(samples[i]);
            }
        }

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

                lock (_sfxLock)
                {
                    _activeSfxPlayers.Add((waveOut, reader));
                }

                waveOut.PlaybackStopped += (s, e) =>
                {
                    try
                    {
                        lock (_sfxLock)
                        {
                            _activeSfxPlayers.Remove((waveOut, reader));
                        }
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

        /// <summary>
        /// Giải phóng hoàn toàn toàn bộ tài nguyên âm thanh, dừng mọi luồng và giải phóng khóa file asset
        /// </summary>
        public void Shutdown()
        {
            _isRunning = false;
            _hasTaskEvent.Set();

            // 1. Dừng và giải phóng toàn bộ luồng nhạc nền BGM ngay lập tức
            StopBgmInternal();

            // 2. Dừng và giải phóng toàn bộ hiệu ứng âm thanh SFX đang phát dở
            lock (_sfxLock)
            {
                foreach (var (waveOut, reader) in _activeSfxPlayers)
                {
                    try
                    {
                        waveOut.Stop();
                        waveOut.Dispose();
                        reader.Dispose();
                    }
                    catch { }
                }
                _activeSfxPlayers.Clear();
            }

            // 3. Xóa cache đường dẫn
            _verifiedSoundPaths.Clear();

            // 4. Đợi worker thread kết thúc gọn gàng
            try
            {
                if (_audioWorkerThread.IsAlive)
                {
                    _audioWorkerThread.Join(500);
                }
            }
            catch { }
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
