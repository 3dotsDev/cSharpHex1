#nullable enable
using System.Collections.Generic;
using Domain.BusinessObjects;

namespace Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer? CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        List<Customer> FindAll();
        Customer? FindCustomerById(int customerId);
    }
}