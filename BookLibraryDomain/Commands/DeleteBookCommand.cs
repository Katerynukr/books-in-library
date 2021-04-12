using BookLibraryDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Commands
{
    public class DeleteBookCommand : ICommand
    {
        private readonly IWriter _writer;
        private readonly IFileService _fileService;

        public DeleteBookCommand(IWriter writer, IFileService fileService)
        {
            _writer = writer;
            _fileService = fileService;
        }

        public void Execute()
        {
            var bookName = _writer.ReadLine("Please enter the name of the book");

            var existingBooks = _fileService.GetAll();

            var filteredBooks = existingBooks.Where(b => b.Name != bookName);

            _fileService.Overwrite(filteredBooks);
        }
    }
}
