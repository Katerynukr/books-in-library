using BookLibraryDomain.Interfaces;
using BookLibraryDomain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Services
{
    public class JsonFileService : IFileService
    {
        private readonly string _dataUrl = AppDomain.CurrentDomain.BaseDirectory +  @"\\BookList.json";

        public IEnumerable<Book> GetAll()
        {
            var books = new List<Book>();

            var lines = File.ReadAllLines(_dataUrl);
            foreach(var line in lines)
            {
                var book = JsonConvert.DeserializeObject<Book>(line);
                books.Add(book);
            }
            var jsonString = File.ReadAllText(_dataUrl);

            return books;
        }

        public void Overwrite(IEnumerable<Book> books)
        {
            File.WriteAllText(_dataUrl, "");

            foreach(var book in books)
            {
                SaveBook(book);
            }
        }

        public void SaveBook(Book book)
        {
            var jsonString = JsonConvert.SerializeObject(book);
            File.AppendAllText(_dataUrl, jsonString + Environment.NewLine);
        }
    }
}
