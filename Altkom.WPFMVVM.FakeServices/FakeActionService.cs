using Altkom.WPFMVVM.IServices;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.WPFMVVM.FakeServices
{
    public class FakeActionService : FakeEntityService<Models.Action>, IActionService
    {
        public FakeActionService(Faker<Models.Action> faker) : base(faker)
        {
        }
    }
}
