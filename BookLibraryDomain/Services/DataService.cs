using BookLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Services
{
    public class DataService
    {
        public Dictionary<string, List<TakeInformation>> TakeInformation = new();
        public List<Book> TakenBooks = new();
    }
}
