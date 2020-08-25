#nullable enable
using System.Collections.Generic;
using Domain.BusinessObjects;

namespace LeftDriver.Adapter.Rest
{
    public interface ICustomerController
    {
        IEnumerable<Customer> List();
        Customer? GetById(int customerId);
        Customer? Register(string lastName, string firstname);
        bool Upgrade(int customerId);
        bool Downgrade(int customerId);
    }
}