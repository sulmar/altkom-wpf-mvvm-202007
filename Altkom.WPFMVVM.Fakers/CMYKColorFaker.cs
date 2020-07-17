using Altkom.WPFMVVM.Models;
using Bogus;

namespace Altkom.WPFMVVM.Fakers
{
    public class CMYKColorFaker : Faker<CMYKColor>
    {
        public CMYKColorFaker()
        {
            RuleFor(p => p.C, f => f.Random.Int(0, 100));
            RuleFor(p => p.M, f => f.Random.Int(0, 100));
            RuleFor(p => p.Y, f => f.Random.Int(0, 100));
            RuleFor(p => p.K, f => f.Random.Int(0, 100));
        }
    }
}
