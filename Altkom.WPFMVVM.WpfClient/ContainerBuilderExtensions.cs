using Altkom.WPFMVVM.FakeServices;
using Altkom.WPFMVVM.FakeServices.Fakers;
using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using Autofac;
using Bogus;

namespace Altkom.WPFMVVM.WpfClient
{
    // PM> Install-Package AutoFac
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddDbServices(this ContainerBuilder containerBuilder)
        {

            // TODO:
            return containerBuilder;
        }
        public static ContainerBuilder AddFakeServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.AddFakeCustomers();
            containerBuilder.AddFakeProducts();

            return containerBuilder;
        }

        public static ContainerBuilder AddFakeCustomers(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<FakeCustomerService>().As<ICustomerService>();
            containerBuilder.RegisterType<CustomerFaker>().As<Faker<Customer>>();

            return containerBuilder;
        }

        public static ContainerBuilder AddFakeProducts(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<FakeProductService>().As<IProductService>();
            containerBuilder.RegisterType<ProductFaker>().As<Faker<Product>>();
            containerBuilder.RegisterType<CMYKColorFaker>().As<Faker<CMYKColor>>();

            return containerBuilder;
        }

    }
}
