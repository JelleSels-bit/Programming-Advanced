using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Models
{
    public class Author
    {
        public List<Book> BooksWritten { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => FirstName + ' ' + LastName;
    }
}
