using Altkom.WPFMVVM.FakeServices;
using Altkom.WPFMVVM.FakeServices.Fakers;
using Altkom.WPFMVVM.ViewModels;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.WPFMVVM.WpfClient
{


    public class ViewModelLocator
    {
        private IContainer container;

        public ViewModelLocator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ProductsViewModel>().SingleInstance();
            containerBuilder.RegisterType<CustomersViewModel>().SingleInstance();

#if DEBUG           
            containerBuilder.AddFakeServices();
#else
            containerBuilder.AddDbServices();
#endif

            container = containerBuilder.Build();

            // co jest potrzebne | czego uzyc           | cykl zycia
            // IProductService   | FakeProductService   | singleton
            // Faker<Product>    | ProductFaker         | 
            // Faker<CMYKColor>  | CMYKColorFaker
        }

        // public ProductsViewModel ProductsViewModel => new ProductsViewModel(new FakeProductService(new ProductFaker(new CMYKColorFaker())));
        public ProductsViewModel ProductsViewModel => container.Resolve<ProductsViewModel>();
        public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();
    }
}
