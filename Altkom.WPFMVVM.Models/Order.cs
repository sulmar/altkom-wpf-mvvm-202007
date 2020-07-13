using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.WPFMVVM.Models
{
    public class Order : BaseEntity
    {
        public string Number { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderDetail> Details { get; set; }
        public decimal TotalAmount => Details.Sum(d => d.Amount);

        public Order()
        {
            foreach (var detail in Details)
            {
                detail.PropertyChanged += Detail_PropertyChanged;
            }
        }

        private void Detail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName=="UnitPrice" || e.PropertyName=="Quantity")
            {
                OnPropertyChanged(nameof(TotalAmount));
            }
        }
    }
}
