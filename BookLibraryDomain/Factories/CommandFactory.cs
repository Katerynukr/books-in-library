using BookLibraryDomain.Commands;
using BookLibraryDomain.Enums;
using BookLibraryDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Factories
{
    public class CommandFactory
    {
        public ICommand Build(string input)
        {
            var commands = Enum.GetNames(typeof(CommandEnums)).ToList();
            if (commands.Any(c => input.Contains(c)))
            {
                return new AddNewBookCommand();
            }
            throw new ArgumentException("Command was not recognied");
        }
    }
}
