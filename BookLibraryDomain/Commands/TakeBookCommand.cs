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
    public class TakeBookCommand : Interfaces.ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;
        private readonly DataService _dataService;

        public TakeBookCommand(IWriter writer, IFileService fileService, DataService dataService)
        {
            _writer = writer;
            _fileService = fileService;
            _dataService = dataService;
        }

        public void Execute()
        {
            var booksNames = _writer.ReadLine("Please enter the names of the books");
            var customerName = _writer.ReadLine("Please enter your Name");
            var books = _fileService.GetAll();
            AddInfoToTaken(books, booksNames, customerName);
            DeleteBook(books, booksNames);
        }

        private void DeleteBook(IEnumerable<Book> books, string bookName)
        {
            var filteredBooks = books.Where(b => b.Name != bookName);
            _fileService.Overwrite(filteredBooks);
        }

        private void AddInfoToTaken(IEnumerable<Book> books, string booksNames, string customerName)
        {
            var booksToTake = new List<Book>();
            foreach(var bookName in booksNames)
            {
                booksToTake.Add(books.FirstOrDefault(b => b.Name == booksNames));
            }
            var booksTakeInfo = new List<TakeInformation>();
            booksToTake.ForEach(b => booksTakeInfo.Add(new TakeInformation() { BookName = b.Name }));

            _dataService.TakeInformation.Add(customerName, booksTakeInfo);
        }
    }
}
