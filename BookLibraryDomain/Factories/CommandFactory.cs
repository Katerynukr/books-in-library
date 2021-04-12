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
            Enum.TryParse(input, out CommandEnums commandEnum);
            switch(commandEnum)
            {
                case CommandEnums.Add:
                    return new AddNewBookCommand(_writer, _fileService)
                case CommandEnums.Delete:
                    return new DeleteBookCommand(_writer, _fileService);
                case CommandEnums.Borrow:
                    return new TakeCommand(_writer, _fileService);
            }
            throw new ArgumentException("Command was not recognied");
        }
    }
}
