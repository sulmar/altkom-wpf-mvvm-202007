namespace Altkom.WPFMVVM.Models
{
    public class OrderDetail : BaseEntity
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount => UnitPrice * Quantity;        
    }
}
