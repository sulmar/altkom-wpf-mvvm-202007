using Altkom.WPFMVVM.IServices;

namespace Altkom.WPFMVVM.DbServices
{
    public class DbActionService : DbEntityService<Models.Action>, IActionService
    {
        public DbActionService(MyContext context) : base(context)
        {
        }
    }
}
