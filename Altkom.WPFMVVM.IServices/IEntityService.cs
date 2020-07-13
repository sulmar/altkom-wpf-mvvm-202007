using Altkom.WPFMVVM.Models;
using System.Collections.Generic;

namespace Altkom.WPFMVVM.IServices
{
    // interfejs generyczny (uogólniony)
    public interface IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }
}