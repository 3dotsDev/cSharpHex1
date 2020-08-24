using System;

namespace Domain.BusinessObjects
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MemberStatus Status { get; set; }
        public int RewardPoints { get; set; }
    }
}