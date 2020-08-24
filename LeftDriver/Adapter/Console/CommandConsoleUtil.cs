using Domain.BusinessObjects;

namespace LeftDriver.Adapter.Console
{
    public class CommandConsoleUtil
    {
        public static string ReadString()
        {
            System.Console.Write("> ");
            return System.Console.ReadLine();
        }

        public static void PrintCustomer(Customer customer)
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"Customer Id: {customer.CustomerId}");
            System.Console.WriteLine($"Customer Name: {customer.FirstName} {customer.LastName}");
            System.Console.WriteLine($"Customer Points: {customer.RewardPoints}");
            System.Console.WriteLine($"Customer Status: {customer.Status}");
        }

        public static void PrintMainMenu()
        {
            System.Console.WriteLine("LS : list all customers");
            System.Console.WriteLine("REG : register a customer");
            System.Console.WriteLine("UG : upgrade a customer");
            System.Console.WriteLine("DG : downgrade a customer");
            System.Console.WriteLine("INFO : show main menu command");
            System.Console.WriteLine("EXIT : exit application");
        }
    }
}