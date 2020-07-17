using Altkom.WPFMVVM.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using Action = Altkom.WPFMVVM.Models.Action;
using System.Linq;

namespace Altkom.WPFMVVM.Fakers
{
    public class PartFaker : Faker<Part>
    {
        public PartFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.SerialNumber, f => f.Commerce.Ean13());
        }
    }

    public class EventFaker : Faker<Event>
    {
        public EventFaker(Faker<Part> partFaker)
        {
            IEnumerable<Part> parts = partFaker.Generate(10);

            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.From, f => f.Date.Between(DateTime.Parse("2020-07-15 06:00"), DateTime.Parse("2020-07-15 14:00")));
            RuleFor(p => p.To, (f, e) => f.Date.Between(e.From.AddMinutes(1), e.From.AddMinutes(5)));
            RuleFor(p => p.Part, f => f.PickRandom(parts));
        }
    }

    public class ActionFaker : Faker<Action>
    {
        public ActionFaker(Faker<Event> eventFaker)
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Hacker.Verb());
            RuleFor(p => p.Number, f => f.IndexFaker + 1);
            RuleFor(p => p.Events, f => eventFaker.Generate(f.Random.Short(3, 7)).OrderBy(e=>e.From));
        }
    }
}
