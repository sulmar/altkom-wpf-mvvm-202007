using System;

namespace Altkom.WPFMVVM.Models
{

    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Photo { get; set; }
        public decimal Salary { get; set; }

        private bool isRemoved;
        public bool IsRemoved
        {
            get => isRemoved;
            set => isRemoved = value;
        }
    }
}
