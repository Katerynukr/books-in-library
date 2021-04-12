using BookLibraryApplication;
using BookLibraryApplication.Writers;
using BookLibraryDomain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryConsoleRunner
{
    public static class DepedencyInjection
    {
        public static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<BookLibraryCLI>()
                .AddSingleton<IWriter, ConsoleWriter>()
                .BuildServiceProvider();
        }
    }
}
