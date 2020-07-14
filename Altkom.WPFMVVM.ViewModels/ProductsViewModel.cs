using Altkom.WPFMVVM.FakeServices;
using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.WPFMVVM.ViewModels
{

    public class ProductsViewModel : BaseViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public Product SelectedProduct { get; set; }

        private readonly IProductService productService;

        public ProductsViewModel()
            : this(new FakeProductService())
        {
        }

        public ProductsViewModel(IProductService productService)
        {
            this.productService = productService;

            Load();
        }

        private void Load()
        {
            Products = productService.Get();
        }
    }
}
