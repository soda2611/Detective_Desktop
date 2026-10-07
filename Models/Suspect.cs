using System;

namespace _2611_WIN_B3.Models
{
    /// <summary>
    /// Lớp Suspect đại diện cho Nghi phạm trong cuộc điều tra
    /// Minh họa đóng gói toàn diện với private backing fields, get/set và validation
    /// </summary>
    public class Suspect : IInspectable
    {
        private string _id = string.Empty;
        private string _name = string.Empty;
        private string _role = string.Empty;
        private string _description = string.Empty;
        private string _possibleMotive = string.Empty;
        private string _alibi = string.Empty;

        public string Id
        {
            get => _id;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã nghi phạm không được để trống!");
                _id = value.Trim().ToUpper();
            }
        }

        public string Name
        {
            get => _name;
            set => _name = value?.Trim() ?? string.Empty;
        }

        public string Role
        {
            get => _role;
            set => _role = value?.Trim() ?? string.Empty;
        }

        public string Description
        {
            get => _description;
            set => _description = value?.Trim() ?? string.Empty;
        }

        public string PossibleMotive
        {
            get => _possibleMotive;
            set => _possibleMotive = value?.Trim() ?? string.Empty;
        }

        public string Alibi
        {
            get => _alibi;
            set => _alibi = value?.Trim() ?? string.Empty;
        }

        public Suspect() { }

        public Suspect(string id, string name, string role, string motive, string alibi)
        {
            Id = id;
            Name = name;
            Role = role;
            PossibleMotive = motive;
            Alibi = alibi;
        }

        public virtual string GetInspectionSummary()
        {
            return $"[Nghi phạm {Id}] {Name} ({Role}) | Động cơ: {PossibleMotive} | Ngoại phạm: {Alibi}";
        }

        public override string ToString() => $"{Name} ({Role})";
    }
}

