using BookLibraryApplication;
using BookLibraryApplication.Writers;
using BookLibraryDomain.Factories;
using BookLibraryDomain.Interfaces;
using BookLibraryDomain.Services;
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
                .AddSingleton<CommandFactory>()
                .AddSingleton<IWriter, ConsoleWriter>()
                .AddSingleton<IFileService, JsonFileService>()
                .AddSingleton<IWriter, ConsoleWriter>()
                .BuildServiceProvider();
        }
    }
}
