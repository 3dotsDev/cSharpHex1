#nullable enable
using System.Collections.Generic;
using Domain.BusinessObjects;
using Domain.Repository;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repo;

        //DI Repo
        public CustomerService(ICustomerRepository repo)
        {
            this._repo = repo;
        }

        public Customer? RegisterCustomer(Customer customer)
        {
            return _repo.CreateCustomer(customer);
        }

        public Customer UpgradeCustomer(Customer customer)
        {
            switch (customer.Status)
            {
                case MemberStatus.Bronze:
                    customer.Status = MemberStatus.Silver;
                    break;
                case MemberStatus.Silver:
                case MemberStatus.Gold:
                    customer.Status = MemberStatus.Gold;
                    break;
            }

            return _repo.UpdateCustomer(customer);
        }

        public Customer DownGradeCustomer(Customer customer)
        {
            switch (customer.Status)
            {
                case MemberStatus.Gold:
                    customer.Status = MemberStatus.Silver;
                    break;
                case MemberStatus.Silver:
                case MemberStatus.Bronze:
                    customer.Status = MemberStatus.Bronze;
                    break;
            }

            return _repo.UpdateCustomer(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.FindAll();
        }

        public Customer? FindCustomerById(int customerId)
        {
            return _repo.FindCustomerById(customerId);
        }
    }
}