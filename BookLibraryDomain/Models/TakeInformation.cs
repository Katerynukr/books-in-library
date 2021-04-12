using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDomain.Models
{
    public class TakeInformation
    {
        public string BookName { get; set; }
        public DateTime From { get; set; } = DateTime.Now;
        public DateTime To { get; set; } = DateTime.Now.AddMonths(2);
    }
}
