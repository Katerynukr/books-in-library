using BookLibraryDomain.Enums;
using BookLibraryDomain.Extentions;
using BookLibraryDomain.Factories;
using BookLibraryDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryApplication
{
    public class BookLibraryCLI
    {
        private readonly CommandFactory _commandFactory;
        private readonly IWriter _writer;

        public BookLibraryCLI(CommandFactory commandFactory, IWriter writer)
        {
            _commandFactory = commandFactory;
            _writer = writer;
        }

        public void PrintCommands()
        {
            _writer.PrintLine("Commands:");
            var commands = Enum.GetValues(typeof(CommandEnums)).Cast<CommandEnums>();
            foreach(var command in commands)
            {
                _writer.PrintLine($"{command } : {command.ToDescriptionString()}");
            }
        }

        public void ReadAndExecuteMethod()
        {
            try 
            {
                _writer.PrintLine("Enter your command: ");
                var commandString = _writer.ReadLine();

                var command = _commandFactory.Build(commandString);
                command.Execute();
            }
            catch(ArgumentException e)
            {
                _writer.PrintLine(e.Message);
            }
        }
    }
}
