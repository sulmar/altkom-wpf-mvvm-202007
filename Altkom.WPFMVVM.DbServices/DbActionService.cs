using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Altkom.WPFMVVM.DbServices
{
    public class DbActionService : DbEntityService<Models.Action>, IActionService
    {
        public DbActionService(MyContext context) : base(context)
        {
        }

        public override IEnumerable<Action> Get()
        {
            return entities.Include(p => p.Events.Select(e => e.Part)).ToList();
        }
    }
}
