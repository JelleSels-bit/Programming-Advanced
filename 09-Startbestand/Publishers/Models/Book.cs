using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Models
{
    public class Book
    {
        public Publisher publisher { get; set; }
        public List<AuthorOfBook> authorOfBooks { get; set; }
    }
}
