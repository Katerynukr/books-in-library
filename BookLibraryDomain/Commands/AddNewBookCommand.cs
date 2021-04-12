using BookLibraryDomain.Interfaces;
using BookLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Commands
{
    public class AddNewBookCommand : ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;

        public AddNewBookCommand(IWriter writer, IFileService fileService)
        {
            _writer = writer;
            _fileService = fileService;
        }

        public void Execute()
        {
            var model = ReadInputToModel();
            Store(model);
        }

        private Book ReadInputToModel()
        {
            var model = new Book();
            PropertyInfo[] properties = typeof(Book).GetProperties();
            foreach(var property in properties)
            {
                var value = _writer.ReadLine($"Please enter value for {property.Name}");
                property.SetValue( model , value);
            }
            return model;
        }
        private void Store(Book book)
        {
            _fileService.SaveNewBook(book);
        }
    }
}
