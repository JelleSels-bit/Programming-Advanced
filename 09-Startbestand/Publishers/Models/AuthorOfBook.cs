using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Models
{
    public class AuthorOfBook
    {
        public Book book { get; set; }
        public Author Author { get; set; }  
    }
}
