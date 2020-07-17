using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Altkom.WPFMVVM.DbServices
{
    public abstract class DbEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly MyContext context;

        protected DbSet<TEntity> entities => context.Set<TEntity>();

        public DbEntityService(MyContext context)
        {
            this.context = context;
        }

        public virtual void Add(TEntity entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return entities.ToList();
        }

        public virtual TEntity Get(int id)
        {
            return entities.Find(id);
        }

        public virtual void Remove(int id)
        {
            TEntity entity = Get(id);
            entities.Remove(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            entities.Attach(entity);
            context.SaveChanges();
        }
    }
}
