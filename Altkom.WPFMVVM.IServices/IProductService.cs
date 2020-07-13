using Altkom.WPFMVVM.Models;
using System.Collections.Generic;

namespace Altkom.WPFMVVM.IServices
{
    public interface IProductService : IEntityService<Product>
    {
        IEnumerable<Product> Get(string color);
    }
}