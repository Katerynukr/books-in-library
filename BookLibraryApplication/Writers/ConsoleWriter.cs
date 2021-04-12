using BookLibraryDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryApplication.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void PrintLine(string input)
        {
            Console.WriteLine(input);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
