namespace Altkom.WPFMVVM.Models
{

    public class Product : BaseEntity
    {
        private string name;
        private string color;
        private decimal unitPrice;
        private Category category; // Navigation Property

        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Color
        {
            get => color; set
            {
                color = value;
                OnPropertyChanged();
            }
        }
        public decimal UnitPrice
        {
            get => unitPrice; set
            {
                unitPrice = value;
                OnPropertyChanged();
            }
        }

        public CMYKColor CMYKColor { get; set; }

        public Category Category
        {
            get => category; set
            {
                category = value;
                OnPropertyChanged();
            }
        }


    }
}
