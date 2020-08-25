using Domain.Repository;
using Domain.Services;
using LeftDriver.Adapter.Console;
using Microsoft.Extensions.DependencyInjection;
using RightDriven.Adapter.Repository;
using RightDriven.Adapter.Repository.InMemory;
using RightDriven.Adapter.Repository.Postgresql;

namespace LeftDriver.Adapter.Rest
{
    public static class CustomerControllerModule
    {
        public static ServiceCollection ConfigureIocContainer()
        {
            var iocContainer = new ServiceCollection();
            iocContainer.AddScoped<ICustomerController, CustomerController>(); //Todo KEV
            iocContainer.AddScoped<ICustomerService, CustomerService>();
            iocContainer.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>(); // Todo KEV
            // iocContainer.AddScoped<ICustomerRepository, PostgresqlRepository>(); // Todo KEV

            return iocContainer;
        }
    }
}