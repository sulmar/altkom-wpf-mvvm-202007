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
    public abstract class DbEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        private readonly MyContext context;

        protected DbSet<TEntity> entities => context.Set<TEntity>();

        public DbEntityService(MyContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> Get()
        {
            return entities.ToList();
        }

        public TEntity Get(int id)
        {
            return entities.Find(id);
        }

        public void Remove(int id)
        {
            TEntity entity = Get(id);
            entities.Remove(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entities.Attach(entity);
            context.SaveChanges();
        }
    }

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
