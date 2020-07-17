using Altkom.WPFMVVM.Models;
using System.Data.Entity.ModelConfiguration;

namespace Altkom.WPFMVVM.DbServices.Configurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            Property(p => p.LastName).HasMaxLength(50).IsRequired();
        }
    }
}
