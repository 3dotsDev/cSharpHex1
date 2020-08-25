#nullable enable
using System;
using System.Collections.Generic;
using Domain.BusinessObjects;
using Domain.Services;

namespace LeftDriver.Adapter.Rest
{
    public class CustomerController : ICustomerController
    {
        private readonly ICustomerService _customerService;

        //DI
        public
            CustomerController(ICustomerService customerService) //Todo KEV  gleicher Service ( Domain bleibt bestehen )
        {
            _customerService = customerService;
        }

        public IEnumerable<Customer> List()
        {
            return _customerService.GetAllCustomers();
        }

        public Customer? GetById(int customerId)
        {
            return _customerService.FindCustomerById(customerId);
        }

        public Customer? Register(string lastName, string firstName)
        {
            Customer customer = new Customer();
            customer.LastName = lastName;
            customer.FirstName = firstName;
            return _customerService.RegisterCustomer(customer);
        }

        public bool Upgrade(int customerId)
        {
            Customer? customer = _customerService.FindCustomerById(customerId);
            if (customer == null)
            {
                return false;
            }

            if (_customerService.UpgradeCustomer(customer) == null)
            {
                return false;
            }

            return true;
        }

        public bool Downgrade(int customerId)
        {
            Customer? customer = _customerService.FindCustomerById(customerId);
            if (customer == null)
            {
                return false;
            }

            if (_customerService.DownGradeCustomer(customer) == null)
            {
                return false;
            }

            return true;
        }
    }
}