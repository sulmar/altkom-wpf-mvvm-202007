using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;

namespace Altkom.WPFMVVM.DbServices
{
    public class DbCustomerService : DbEntityService<Customer>, ICustomerService
    {
        public DbCustomerService(MyContext context) : base(context)
        {
        }

        public override void Remove(int id)
        {
            Customer customer = Get(id);
            customer.IsRemoved = true;
            context.SaveChanges();
        }
    }
}
