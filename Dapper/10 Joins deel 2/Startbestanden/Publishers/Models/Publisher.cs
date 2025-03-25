using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<Book> Books { get; set; }
        public string TitleInfo()
        {
            string result = "";

            if (this.Books.Count() >= 1)
            {
                foreach (Book book in this.Books)
                {
                    result += $"{book.Title} {book.AuthorInfo()} \n\n";
                }
            }
            else
            {
                result += $"{this.Name} heeft geen publicaties.";
            }
            return result;
        }
    }
}