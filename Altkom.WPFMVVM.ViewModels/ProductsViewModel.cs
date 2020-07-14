using Altkom.WPFMVVM.FakeServices;
using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Altkom.WPFMVVM.ViewModels
{
    
    public class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public Product SelectedProduct { get; set; }

        public bool IsIncrement { get; set; }

        private readonly IProductService productService;

        public ProductsViewModel()
            : this(new FakeProductService())
        {
            
        }

        public ProductsViewModel(IProductService productService)
        {
            this.productService = productService;

            CalculateCommand = new DelegateCommand(Calculate);
            RemoveCommand = new DelegateCommand(Remove);

            Load();
        }

        private void Load()
        {            
            // Products = new ObservableCollection<Product>(productService.Get());

            // z uzyciem (wlasnej) metody rozszerzajacej
            Products = productService.Get().AsObservable();
        }

        public ICommand CalculateCommand { get; }
        public ICommand RemoveCommand { get; }

        private void Calculate()
        {
            if (IsIncrement)
                SelectedProduct.UnitPrice = SelectedProduct.UnitPrice * 2;
            else
                SelectedProduct.UnitPrice = SelectedProduct.UnitPrice / 2;
        }

        private void Remove()
        {
            productService.Remove(SelectedProduct.Id);
            Products.Remove(SelectedProduct);
        }
    }
}
