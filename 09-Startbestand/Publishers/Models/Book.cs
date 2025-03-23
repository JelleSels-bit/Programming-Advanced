using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Models
{
    public class Book
    {
        public string Title { get; set; }
        public int aantalBoek { get; set; }  
        public DateTime VerkoopDatum { get; set; }
        public Publisher Publisher { get; set; }
        public List<AuthorOfBook> AuthorOfBooks { get; set; }

        public override string ToString()
        {
            return $"{Title} {Publisher} {VerkoopDatum}";
        }
    }
}
