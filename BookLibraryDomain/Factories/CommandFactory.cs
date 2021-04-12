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
        private readonly IWriter _writer;
        private readonly IFileService _fileService;

        public CommandFactory(IWriter writer, IFileService fileService)
        {
            _writer = writer;
            _fileService = fileService;
        }

        public ICommand Build(string input)
        {
            var commands = Enum.GetNames(typeof(CommandEnums)).ToList();
            if (commands.Any(c => input.Contains(c)))
            {
                return new AddNewBookCommand(_writer, _fileService);
            }
            throw new ArgumentException("Command was not recognied");
        }
    }
}
