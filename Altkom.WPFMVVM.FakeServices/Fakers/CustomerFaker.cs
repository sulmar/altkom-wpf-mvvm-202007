﻿using Altkom.WPFMVVM.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.WPFMVVM.FakeServices.Fakers
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
             // RuleFor(p => p.Salary, f => f.Random.Decimal(100, 200));
            Ignore(p => p.Salary);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));
            
            RuleFor(p => p.Salary, f => f.Commerce.Random.Decimal(100, 200));
        }
    }

    // Generowanie PESEL
    // https://github.com/sulmar/Bogus.Extensions.Poland
}
