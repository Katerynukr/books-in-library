using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Interfaces
{
    public interface IWriter
    {
        void PrintLine(string input);
        string ReadLine(string message);
    }
}
