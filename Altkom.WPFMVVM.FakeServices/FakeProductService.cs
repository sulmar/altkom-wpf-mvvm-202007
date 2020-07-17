using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using Bogus;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.WPFMVVM.FakeServices
{
    public class FakeProductService : FakeEntityService<Product>, IProductService
    {
        //public FakeProductService()
        //    : this(new ProductFaker(new CMYKColorFaker()))
        //{

        //}

        public FakeProductService(Faker<Product> faker) : base(faker)
        {
        }

        public IEnumerable<Product> Get(string color)
        {
            return entities.Where(p => p.Color == color);
        }
    }
}
