#nullable enable
using System;
using System.Collections.Generic;
using Domain.BusinessObjects;
using Domain.Services;

namespace LeftDriver.Adapter.Console
{
    public class Command : ICommand
    {
        private readonly ICustomerService _customerService;

        //DI
        public Command(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        public void List()
        {
            System.Console.WriteLine("All customers registered so far");

            List<Customer> customers = _customerService.GetAllCustomers();

            customers.ForEach(c =>
            {
                CommandConsoleUtil.PrintCustomer(c);
                System.Console.WriteLine("--------------");
            });
        }

        public void Register()
        {
            System.Console.WriteLine("What is the Firstname");
            string firstName = CommandConsoleUtil.ReadString();
            System.Console.WriteLine("What is the Lastname");
            string lastName = CommandConsoleUtil.ReadString();

            Customer customerUnregistered = new Customer();
            customerUnregistered.FirstName = firstName;
            customerUnregistered.LastName = lastName;
            Customer? customerRegistered = _customerService.RegisterCustomer(customerUnregistered);

            System.Console.WriteLine("Customer registered successfully with the following : ");
            CommandConsoleUtil.PrintCustomer(customerRegistered);
        }

        public void Upgrade()
        {
            System.Console.WriteLine("What is the customer Id you want to upgrade? ");
            string customerId = CommandConsoleUtil.ReadString();
            Customer? customer = _customerService.FindCustomerById(int.Parse(customerId));

            if (customer != null)
            {
                System.Console.WriteLine("The Customer you want to upgrade is as following");
                CommandConsoleUtil.PrintCustomer(customer);
                System.Console.WriteLine("Do you want to proceed ? Y(es)/N(o)");
                string confirmationRespond = CommandConsoleUtil.ReadString();
                if (confirmationRespond.Equals("yes", StringComparison.InvariantCultureIgnoreCase) ||
                    confirmationRespond.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        Customer? updatedCustomer = _customerService.UpgradeCustomer(customer);
                        System.Console.WriteLine("Customer upgrade successful with the following : ");
                        CommandConsoleUtil.PrintCustomer(updatedCustomer);
                    }
                    catch (Exception)
                    {
                        System.Console.WriteLine("Customer upgrade failed");
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong Key ");
                }
            }
            else
            {
                System.Console.WriteLine("Can't find the customer with supplied Id. Please try again ");
            }
        }

        public void Downgrade()
        {
            System.Console.WriteLine("What is the customer Id you want to downgrade? ");
            string customerId = CommandConsoleUtil.ReadString();
            Customer? customer = _customerService.FindCustomerById(int.Parse(customerId));

            if (customer != null)
            {
                System.Console.WriteLine("The Customer you want to downgrade is as following");
                CommandConsoleUtil.PrintCustomer(customer);
                System.Console.WriteLine("Do you want to proceed ? Y(es)/N(o)");
                string confirmationRespond = CommandConsoleUtil.ReadString();
                if (confirmationRespond.Equals("yes", StringComparison.InvariantCultureIgnoreCase) ||
                    confirmationRespond.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        Customer? updatedCustomer = _customerService.DownGradeCustomer(customer);
                        System.Console.WriteLine("Customer downgrade successful with the following : ");
                        CommandConsoleUtil.PrintCustomer(updatedCustomer);
                    }
                    catch (Exception)
                    {
                        System.Console.WriteLine("Customer downgrade failed");
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong Key ");
                }
            }
            else
            {
                System.Console.WriteLine("Can't find the customer with supplied Id. Please try again ");
            }
        }

        public void Info()
        {
            CommandConsoleUtil.PrintMainMenu();
        }
    }
}