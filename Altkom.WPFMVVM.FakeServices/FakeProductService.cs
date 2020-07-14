using Altkom.WPFMVVM.FakeServices.Fakers;
using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altkom.WPFMVVM.FakeServices
{
    public class FakeProductService : FakeEntityService<Product>, IProductService
    {
        public FakeProductService()
            : this(new ProductFaker())
        {

        }

        public FakeProductService(Faker<Product> faker) : base(faker)
        {
        }

        public IEnumerable<Product> Get(string color)
        {
            return entities.Where(p => p.Color == color);
        }
    }
}
