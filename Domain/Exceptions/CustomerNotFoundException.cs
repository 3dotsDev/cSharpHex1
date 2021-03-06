using System;

namespace Domain.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message) : base(message)
        {
        }

        public CustomerNotFoundException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}