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
        public void SaveNewBook(Book book)
        {
            var jsonString = JsonConvert.SerializeObject(book);
            File.AppendAllText(_dataUrl, jsonString);
        }
    }
}
