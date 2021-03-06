﻿using Altkom.WPFMVVM.Models;
using Bogus;
using Bogus.Extensions.Poland;

namespace Altkom.WPFMVVM.Fakers
{
    // PM> Install-Package Bogus
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {

            UseSeed(1); // zawsze ten sam zbiór
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Photo, f => f.Person.Avatar);
            RuleFor(p => p.Salary, f => decimal.Round( f.Random.Decimal(100, 200), 0));
            RuleFor(p => p.Gender, f => (Gender) f.Person.Gender);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));
            RuleFor(p => p.Birthday, f => f.Person.DateOfBirth);
            RuleFor(p => p.Pesel, f => f.Person.Pesel());
        }
    }

    // Generowanie PESEL
    // https://github.com/sulmar/Bogus.Extensions.Poland
}
