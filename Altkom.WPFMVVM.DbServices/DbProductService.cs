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
    public class DbProductService : IProductService
    {
        private readonly MyContext context;

        private DbSet<Product> entities => context.Products;

        public DbProductService(MyContext context)
        {
            this.context = context;
        }

        public void Add(Product entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<Product> Get(string color)
        {
            return entities.Where(p => p.Color == color).ToList();
        }

        public IEnumerable<Product> Get()
        {
            // Eager loading
            return entities.Include(p => p.Category).ToList();
        }

        public Product Get(int id)
        {
            Product product = entities.Find(id);

            // Explicitly loading
            context.Entry(product).Reference(p => p.Category).Load();

            return product;
        }

        public void Remove(int id)
        {
            Product product = Get(id);
            entities.Remove(product);
            context.SaveChanges();
        }

        public void Update(Product entity)
        {
            entities.Attach(entity);
            context.SaveChanges();
        }
    }
}
