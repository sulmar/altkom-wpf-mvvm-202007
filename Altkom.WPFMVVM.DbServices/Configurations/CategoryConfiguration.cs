using Altkom.WPFMVVM.Models;
using System.Data.Entity.ModelConfiguration;

namespace Altkom.WPFMVVM.DbServices.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
