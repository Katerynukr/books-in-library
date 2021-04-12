using BookLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Interfaces
{
    public interface IFileService
    {
        void SaveNewBook(Book book);

    }
}
