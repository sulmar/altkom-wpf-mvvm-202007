using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.WPFMVVM.DbServices.Configurations
{
    public class ActionConfiguration : EntityTypeConfiguration<Models.Action>
    {
        public ActionConfiguration()
        {
            Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }


}
