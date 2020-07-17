using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.WPFMVVM.DbServices
{

    public class DbProductService : DbEntityService<Product>, IProductService
    {
        public DbProductService(MyContext context) : base(context)
        {
        }

        public IEnumerable<Product> Get(string color)
        {
            return entities.Where(p => p.Color == color).ToList();
        }

        public override IEnumerable<Product> Get()
        {
            return entities.Include(p => p.Category).ToList();
        }

    }
}
