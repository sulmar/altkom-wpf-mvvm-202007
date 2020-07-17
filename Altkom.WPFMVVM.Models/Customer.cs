using System;
using System.ComponentModel;
using System.Linq;

namespace Altkom.WPFMVVM.Models
{

    public class Customer : BaseEntity, IDataErrorInfo
    {
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FullName => $"{FirstName} {LastName}";
        public string Photo { get; set; }
        public decimal Salary { get; set; }

        public bool IsSalaryOverLimit => Salary > 150;

        private string lastName;
        private string firstName;
        private bool isRemoved;

        public bool IsRemoved
        {
            get => isRemoved; 
            set
            {
                isRemoved = value;
                OnPropertyChanged();
            }
        }

        public Gender Gender { get; set; }

        public DateTime Birthday { get; set; }

        public string Pesel { get; set; }

        #region IDataErrorInfo
        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                if (columnName==nameof(FirstName))
                {
                    if (string.IsNullOrWhiteSpace(FirstName))
                    {
                        return "Imie jest wymagane";
                    }

                    if (FirstName.Length < 3)
                    {
                        return "Imie zbyt krotkie";
                    }
                }

                if (columnName == nameof(LastName))
                {
                    if (string.IsNullOrWhiteSpace(LastName))
                    {
                        return "Nazwisko jest wymagane";
                    }
                }

                return null;
            }
        }

        #endregion
    }

    public enum Gender : byte
    {
        [Description("Mezczyzna")]
        Male = 0,

        [Description("Kobieta")]
        Female = 1
    }
}
