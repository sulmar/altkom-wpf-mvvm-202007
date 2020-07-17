using Altkom.WPFMVVM.DbServices;
using Altkom.WPFMVVM.Fakers;
using Altkom.WPFMVVM.FakeServices;
using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using Autofac;
using Bogus;
using System.Configuration;
using System.Data.Entity;

namespace Altkom.WPFMVVM.WpfClient
{
    // PM> Install-Package AutoFac
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddDbServices(this ContainerBuilder containerBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            containerBuilder.RegisterType<MyInitializer>().As<IDatabaseInitializer<MyContext>>();
            containerBuilder.RegisterType<MyContext>().WithParameter("connectionString", connectionString);

            containerBuilder.RegisterType<DbProductService>().As<IProductService>();
            containerBuilder.RegisterType<DbCustomerService>().As<ICustomerService>();
            containerBuilder.RegisterType<DbActionService>().As<IActionService>();

            containerBuilder.AddFakers();

            return containerBuilder;
        }
        public static ContainerBuilder AddFakeServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<FakeCustomerService>().As<ICustomerService>();
            containerBuilder.RegisterType<FakeProductService>().As<IProductService>();
            containerBuilder.RegisterType<FakeActionService>().As<IActionService>();

            containerBuilder.AddFakers();

            return containerBuilder;
        }
        public static ContainerBuilder AddFakers(this ContainerBuilder containerBuilder)
        {
            containerBuilder.AddCustomerFaker();
            containerBuilder.AddProductFaker();
            containerBuilder.AddActionFaker();

            return containerBuilder;
        }
        public static ContainerBuilder AddCustomerFaker(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CustomerFaker>().As<Faker<Customer>>();
            return containerBuilder;
        }
        public static ContainerBuilder AddProductFaker(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ProductFaker>().As<Faker<Product>>();
            containerBuilder.RegisterType<CMYKColorFaker>().As<Faker<CMYKColor>>();
            containerBuilder.RegisterType<CategoryFaker>().As<Faker<Category>>();

            return containerBuilder;
        }
        public static ContainerBuilder AddActionFaker(this ContainerBuilder containerBuilder)
        {            
            containerBuilder.RegisterType<ActionFaker>().As<Faker<Models.Action>>();
            containerBuilder.RegisterType<EventFaker>().As<Faker<Models.Event>>();
            containerBuilder.RegisterType<PartFaker>().As<Faker<Models.Part>>();

            return containerBuilder;
        }


    }
}
