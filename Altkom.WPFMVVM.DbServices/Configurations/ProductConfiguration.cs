using Altkom.WPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.WPFMVVM.DbServices.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {            
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.Color).HasMaxLength(50);
            Property(p => p.CMYKColor.C).HasColumnName("C");
            Property(p => p.CMYKColor.M).HasColumnName("M");
            Property(p => p.CMYKColor.Y).HasColumnName("Y");
            Property(p => p.CMYKColor.K).HasColumnName("K");
        }
    }
}
