﻿using System.Linq;

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

        private bool isRemoved;
        private string lastName;
        private string firstName;

        public bool IsRemoved
        {
            get => isRemoved;
            set => isRemoved = value;
        }




    }
}
