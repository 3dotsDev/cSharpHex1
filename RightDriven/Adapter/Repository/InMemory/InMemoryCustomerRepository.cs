#nullable enable
using System.Collections.Generic;
using System.Linq;
using Domain.BusinessObjects;
using Domain.Exceptions;
using Domain.Repository;

namespace RightDriven.Adapter.Repository.InMemory
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private Dictionary<int, Customer> _dataStore = new Dictionary<int, Customer>();

        public Customer? CreateCustomer(Customer customer)
        {
            customer.CustomerId = RepositoryUtils.GetPrimaryKey();
            customer.RewardPoints = 500;
            customer.Status = MemberStatus.Bronze;
            return _dataStore.TryAdd(customer.CustomerId, customer) ? customer : null;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (!_dataStore.ContainsKey(customer.CustomerId))
            {
                throw new CustomerNotFoundException($"Customer {customer.CustomerId} cant be found");
            }

            _dataStore[customer.CustomerId] = customer;
            return customer;
        }

        public List<Customer> FindAll()
        {
            return _dataStore.Values.ToList();
        }

        public Customer? FindCustomerById(int customerId)
        {
            return !_dataStore.ContainsKey(customerId) ? null : _dataStore[customerId];
        }
    }
}