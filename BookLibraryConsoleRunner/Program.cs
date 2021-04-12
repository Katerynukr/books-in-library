using BookLibraryApplication;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookLibraryConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DepedencyInjection.ConfigureServices();

            var bookLibraryCLI = serviceProvider.GetService<BookLibraryCLI>();

            bookLibraryCLI.PrintCommands();

            while (true)
            {
                bookLibraryCLI.ReadAndExecuteMethod();
            }
        }
    }
}
