using Altkom.WPFMVVM.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.WPFMVVM.Fakers
{
    public class CategoryFaker : Faker<Category>
    {
        public CategoryFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Lorem.Word());
        }
    }
}
