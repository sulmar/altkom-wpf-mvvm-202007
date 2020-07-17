using System;
using System.ComponentModel;
using System.Linq;

namespace Altkom.WPFMVVM.Models
{

    public class Customer : BaseEntity
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

    }

    public enum Gender : byte
    {
        [Description("Mezczyzna")]
        Male = 0,

        [Description("Kobieta")]
        Female = 1
    }
}
