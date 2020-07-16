using Altkom.WPFMVVM.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Altkom.WPFMVVM.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;

        public ShellViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }


        //public ICommand ShowCustomersCommand => new DelegateCommand(ShowCustomers);
        //public ICommand ShowProductsCommand => new DelegateCommand(ShowProducts);
        //public ICommand ShowActionsCommand => new DelegateCommand(ShowActions);

        public ICommand ShowViewCommand => new DelegateCommand<string>(p => ShowView(p));

        private void ShowView(string viewName)
        {
            navigationService.Navigate(viewName);
        }

        //private void ShowCustomers()
        //{
        //    navigationService.Navigate("Customers");
        //}

        //private void ShowProducts()
        //{
        //    navigationService.Navigate("Products");
        //}

        //private void ShowActions()
        //{
        //    navigationService.Navigate("Actions");
        //}
    }


}
