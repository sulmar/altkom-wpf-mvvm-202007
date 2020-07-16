using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using Bogus;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.WPFMVVM.FakeServices
{
    public abstract class FakeEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly ICollection<TEntity> entities;

        public FakeEntityService(Faker<TEntity> faker)
        {
            entities = faker.Generate(10_000);
        }

        public virtual void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public virtual TEntity Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }

        public virtual void Remove(int id)
        {
            entities.Remove(Get(id));
        }

        public virtual void Update(TEntity entity)
        {
            Remove(entity.Id);
            Add(entity);
        }
    }
}
