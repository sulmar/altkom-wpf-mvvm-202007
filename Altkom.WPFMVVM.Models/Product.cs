namespace Altkom.WPFMVVM.Models
{
    public class Product : BaseEntity
    {
        private string name;
        private string color;
        private decimal unitPrice;

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
    }
}
