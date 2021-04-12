using BookLibraryDomain.Interfaces;
using BookLibraryDomain.Models;
using BookLibraryDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookLibraryDomain.Commands
{
    public class TakeCommand : Interfaces.ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;
        private readonly DataService _dataService;

        public TakeCommand(IWriter writer, IFileService fileService, DataService dataService)
        {
            _writer = writer;
            _fileService = fileService;
            _dataService = dataService;
        }

        public void Execute()
        {
            var bookName = _writer.ReadLine("Please enter the name of the book");
            var customerName = _writer.ReadLine("Please enter your Name");
            var books = _fileService.GetAll();
            AddInfoToTaken(books, bookName, customerName);
            DeleteBook(books, bookName);
        }

        private void DeleteBook(IEnumerable<Book> books, string bookName)
        {
            var filteredBooks = books.Where(b => b.Name != bookName);
            _fileService.Overwrite(filteredBooks);
        }

        private void AddInfoToTaken(IEnumerable<Book> books, string bookName, string customerName)
        {
            var book = books.FirstOrDefault(b => b.Name == bookName);
            var takeInfo = new List<TakeInformation>() {
                new TakeInformation()
                {
                     BookName = book.Name
                }
            };

            takeInfo.ForEach(i => _dataService.TakeInformation.Add(customerName, i));
        }
    }
}
