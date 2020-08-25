using System;
using LeftDriver.Adapter.Console;
using LeftDriver.Adapter.Rest;
using Microsoft.Extensions.DependencyInjection;

namespace CommandConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider iocProvider = CommandConsoleModule.ConfigureIocContainer();
            ICommand command = iocProvider.GetService<ICommand>();
            Start(command);
        }

        public static void Start(ICommand commandConsole)
        {
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "LS":
                        commandConsole.List();
                        break;
                    case "REG":
                        commandConsole.Register();
                        break;
                    case "UG":
                        commandConsole.Upgrade();
                        break;
                    case "DG":
                        commandConsole.Downgrade();
                        break;
                    case "INFO":
                        commandConsole.Info();
                        break;
                    case "EXIT":
                        return;
                    default:
                        continue;
                }
            }
        }
    }
}