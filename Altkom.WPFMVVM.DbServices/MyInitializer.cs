using Altkom.WPFMVVM.DbServices.Migrations;
using Altkom.WPFMVVM.Models;
using Bogus;
using System.Data.Entity;

namespace Altkom.WPFMVVM.DbServices
{

    public class MyMigrateInitializer : MigrateDatabaseToLatestVersion<MyContext, Migrations.Configuration>
    {
        public MyMigrateInitializer
            (bool useSuppliedContext, Configuration configuration) : base(useSuppliedContext, configuration)
        {
        }
    }

    public class MyInitializer : CreateDatabaseIfNotExists<MyContext>
    {
        private readonly Faker<Product> productFaker;
        private readonly Faker<Customer> customerFaker;
        private readonly Faker<Models.Action> actionFaker;

        public MyInitializer(Faker<Product> productFaker, Faker<Customer> customerFaker, Faker<Models.Action> actionFaker)
        {
            this.productFaker = productFaker;
            this.customerFaker = customerFaker;
            this.actionFaker = actionFaker;
        }

        protected override void Seed(MyContext context)
        {
            context.Products.AddRange(productFaker.Generate(100));
            context.Customers.AddRange(customerFaker.Generate(2000));
            context.Actions.AddRange(actionFaker.Generate(50));

            base.Seed(context);
        }
    }
}
