using BookLibraryDomain.Commands;
using BookLibraryDomain.Enums;
using BookLibraryDomain.Interfaces;
using BookLibraryDomain.Services;
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
        private readonly DataService _dataService;

        public CommandFactory(IWriter writer, IFileService fileService, DataService dataService)
        {
            _writer = writer;
            _fileService = fileService;
            _dataService = dataService;
        }

        public ICommand Build(string input)
        {
            Enum.TryParse(input, out CommandEnums commandEnum);
            switch(commandEnum)
            {
                case CommandEnums.Add:
                    return new AddNewBookCommand(_writer, _fileService);
                case CommandEnums.Delete:
                    return new DeleteBookCommand(_writer, _fileService);
                case CommandEnums.Take:
                    return new TakeBookCommand(_writer, _fileService, _dataService);
                case CommandEnums.Return:
                    return new ReturnBookCommand(_writer, _fileService, _dataService);
            }
            throw new ArgumentException("Command was not recognied");
        }
    }
}
