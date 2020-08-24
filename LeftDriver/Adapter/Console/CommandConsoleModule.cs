using System.Security.Authentication.ExtendedProtection;
using Domain.Repository;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using RightDriven.Adapter.Repository;

namespace LeftDriver.Adapter.Console
{
    public class CommandConsoleModule
    {
        public static ServiceProvider ConfigureIocContainer()
        {
            var iocContainer = new ServiceCollection();
            iocContainer.AddScoped<ICommand, Command>();
            iocContainer.AddScoped<ICustomerService, CustomerService>();
            iocContainer.AddScoped<ICustomerRepository, InMemoryCustomerRepository>();

            return iocContainer.BuildServiceProvider();
        }
    }
}