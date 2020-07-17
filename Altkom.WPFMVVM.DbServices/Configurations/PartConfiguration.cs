using Altkom.WPFMVVM.Models;
using System.Data.Entity.ModelConfiguration;

namespace Altkom.WPFMVVM.DbServices.Configurations
{
    public class PartConfiguration : EntityTypeConfiguration<Part>
    {
        public PartConfiguration()
        {
            Property(p => p.Name).HasMaxLength(100).IsRequired();
            Property(p => p.SerialNumber).HasMaxLength(20).IsUnicode(false);
        }
    }


}
