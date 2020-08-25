#nullable enable
using System.Collections.Generic;
using Domain.BusinessObjects;
using Domain.Repository;

namespace RightDriven.Adapter.Repository.Postgresql
{
    public class PostgresqlRepository : ICustomerRepository
    {
        //Hier waere die Impl fuer eine Postgres DB
        public Customer? CreateCustomer(Customer customer) //Todo KEV glichs repository aber neui impl.
        {
            throw new System.NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Customer? FindCustomerById(int customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}