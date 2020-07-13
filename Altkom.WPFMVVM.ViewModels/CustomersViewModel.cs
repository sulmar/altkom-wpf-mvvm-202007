using Altkom.WPFMVVM.FakeServices;
using Altkom.WPFMVVM.FakeServices.Fakers;
using Altkom.WPFMVVM.IServices;
using Altkom.WPFMVVM.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.WPFMVVM.ViewModels
{
    public class CustomersViewModel
    {
        public IEnumerable<Customer> Customers { get; private set; }
        public Customer SelectedCustomer { get; set; }

        private readonly ICustomerService customerService;

        public CustomersViewModel()
            : this(new FakeCustomerService(new CustomerFaker()))
        {
        }

        public CustomersViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;
            
            SelectedCustomer = new Customer();
            

            Load();
        }

        private void Load()
        {
            Customers = customerService.Get();
        }
    }
}
