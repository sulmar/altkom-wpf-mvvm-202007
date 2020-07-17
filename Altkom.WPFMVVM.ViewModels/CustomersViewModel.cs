using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace Altkom.WPFMVVM.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        public IEnumerable<Customer> Customers { get; private set; }
        public Customer SelectedCustomer
        {
            get => selectedCustomer; 
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        private readonly ICustomerService customerService;
        private readonly INavigationService navigationService;

        private Customer selectedCustomer;

        //public CustomersViewModel()
        //    : this(new FakeCustomerService(new CustomerFaker()))
        //{
        //}

        public CustomersViewModel(ICustomerService customerService, INavigationService navigationService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;

            SelectedCustomer = new Customer();


            Load();
        }

        private void Load()
        {
            Customers = customerService.Get();
        }

        public ICommand ShowActionsCommand => new DelegateCommand(ShowActions);

        // public ICommand ShowActionsCommand => new DelegateCommand(()=>navigationService.Navigate("Actions"));

        private void ShowActions()
        {
            navigationService.Navigate("Actions");
        }
    }
}
