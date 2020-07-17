using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using Bogus;

namespace Altkom.WPFMVVM.FakeServices
{

    public class FakeCustomerService : FakeEntityService<Customer>, ICustomerService
    {
        //public FakeCustomerService()
        //    : this(new CustomerFaker())
        //{

        //}

        public FakeCustomerService(Faker<Customer> faker) : base(faker)
        {
        }

        public override void Remove(int id)
        {
            Customer customer = Get(id);
            customer.IsRemoved = true;
        }
    }

    //public class FakeCustomerService : ICustomerService
    //{
    //    private readonly ICollection<Customer> customers;

    //    public FakeCustomerService()
    //        : this(new CustomerFaker())
    //    {
    //    }

    //    public FakeCustomerService(Faker<Customer> faker)
    //    {
    //        customers = faker.Generate(100);
    //    }

    //    public void Add(Customer entity)
    //    {
    //        customers.Add(entity);
    //    }

    //    public IEnumerable<Customer> Get()
    //    {
    //        return customers;
    //    }

    //    public Customer Get(int id)
    //    {
    //        return customers.SingleOrDefault(c => c.Id == id);
    //    }

    //    public void Remove(int id)
    //    {
    //        customers.Remove(Get(id));
    //    }

    //    public void Update(Customer entity)
    //    {
    //        Remove(entity.Id);
    //        customers.Add(entity);
    //    }
    //}
}
