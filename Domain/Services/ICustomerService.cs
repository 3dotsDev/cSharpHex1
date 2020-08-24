#nullable enable
using System.Collections.Generic;
using Domain.BusinessObjects;

namespace Domain.Services
{
    public interface ICustomerService
    {
        Customer? RegisterCustomer(Customer customer);
        Customer UpgradeCustomer(Customer customer);
        Customer DownGradeCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer? FindCustomerById(int customerId);
    }
}