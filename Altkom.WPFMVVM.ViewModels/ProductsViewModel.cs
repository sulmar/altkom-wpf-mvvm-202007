using Altkom.WPFMVVM.FakeServices;
using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Linq;

namespace Altkom.WPFMVVM.ViewModels
{

    public class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public IEnumerable<Product> FilteredProducts
        {
            get => filteredProducts; set
            {
                filteredProducts = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Category> Categories => Products
            .Select(p => p.Category)
            .Union(new List<Category> { Category.All })
            .Distinct()
            .OrderBy(p => p.Name);

        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;

                GetProductsByCategory(SelectedCategory);

            }
        }

        private void GetProductsByCategory(Category category)
        {
            if (SelectedCategory == Category.All)
            {
                FilteredProducts = Products;
            }
            else
            {
                FilteredProducts = Products.Where(p => p.Category.Equals(category)).ToList();
            }
        }


        public Product SelectedProduct
        {
            get => selectedProduct; set
            {
                selectedProduct = value;
                OnPropertyChanged();

                ToUpperCommand.OnCanExexuteChanged();

                if (SelectedProduct != null)
                    SelectedProduct.PropertyChanged += (s, e) => ToUpperCommand.OnCanExexuteChanged();

            }
        }

        public bool IsIncrement { get; set; }

        private readonly IProductService productService;
        private Product selectedProduct;
        private Category selectedCategory;
        private IEnumerable<Product> filteredProducts;

        //public ProductsViewModel()
        //    : this(new FakeProductService())
        //{

        //}

        public ProductsViewModel(IProductService productService)
        {
            this.productService = productService;

            CalculateCommand = new DelegateCommand(Calculate);
            RemoveCommand = new DelegateCommand(Remove, CanRemove);
            ToUpperCommand = new DelegateCommand(ToUpper, CanToUpper);

            Load();

        }

        private void Load()
        {
            // Products = new ObservableCollection<Product>(productService.Get());

            // z uzyciem (wlasnej) metody rozszerzajacej
            Products = productService.Get().AsObservable();

            SelectedCategory = Category.All;
        }

        public ICommand CalculateCommand { get; }
        public ICommand RemoveCommand { get; }
        public DelegateCommand ToUpperCommand { get; }

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

        public bool IsSelectedProduct => SelectedProduct != null;

        private bool CanRemove()
        {
            return IsSelectedProduct;
        }

        private void ToUpper()
        {
            SelectedProduct.Name = SelectedProduct.Name.ToUpper();
        }

        private bool CanToUpper()
        {
            return IsSelectedProduct && !string.IsNullOrWhiteSpace(SelectedProduct.Name);
        }
    }
}
