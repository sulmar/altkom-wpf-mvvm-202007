using Altkom.WPFMVVM.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.WPFMVVM.Fakers
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker(Faker<CMYKColor> colorFaker, Faker<Category> categoryFaker)
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.UnitPrice, f => decimal.Round(f.Random.Decimal(100, 200), 2, MidpointRounding.AwayFromZero));
            RuleFor(p => p.CMYKColor, f => colorFaker.Generate());
            RuleFor(p => p.Category, f => categoryFaker.Generate());
        }
    }
}
