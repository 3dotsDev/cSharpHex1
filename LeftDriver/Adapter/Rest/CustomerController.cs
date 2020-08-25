using Domain.Services;

namespace LeftDriver.Adapter.Rest
{
    public class CustomerController : ICustomerController
    {
        private readonly ICustomerService _customerService;

        //DI
        public CustomerController(ICustomerService customerService) //Todo KEV  gleicher Service ( Domain bleibt bestehen )
        {
            _customerService = customerService;
        }
        
        public void List()
        {
            throw new System.NotImplementedException();
        }

        public void Register()
        {
            throw new System.NotImplementedException();
        }

        public void Upgrade()
        {
            throw new System.NotImplementedException();
        }

        public void Downgrade()
        {
            throw new System.NotImplementedException();
        }

        public void Info()
        {
            throw new System.NotImplementedException();
        }
    }
}