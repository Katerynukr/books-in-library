using BookLibraryDomain.Interfaces;
using BookLibraryDomain.Models;
using BookLibraryDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Commands
{
    public class ReturnBookCommand : ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;
        private readonly DataService _dataService;

        public ReturnBookCommand(IWriter writer, IFileService fileService, DataService dataService)
        {
            _writer = writer;
            _fileService = fileService;
            _dataService = dataService;
        }

        public void Execute()
        {
            var bookName = _writer.ReadLine("Please enter the name of the book");
            var customerName = _writer.ReadLine("Please enter your Name");
            ReturnBook(bookName);
            DeleteInfoFromTaken(bookName, customerName);

        }

        private void DeleteInfoFromTaken(string bookName, string customerName)
        {
            _dataService.TakeInformation.Where(i => i.Key == customerName && i.Value.Remove(i.Value.First(n => n.BookName == bookName)));
        }

        private void ReturnBook(string bookName)
        {
            var book = _dataService.TakenBooks.FirstOrDefault(b => b.Name == bookName);
            _fileService.SaveBook(book);

        }
    }
}
