using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Enums
{
    public enum CommandEnums
    {
        [Description("To add new book")]
        Add,
        [Description("To delete a book")]
        Delete,
        [Description("To borrow a book")]
        Borrow,
    }
}
