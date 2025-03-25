using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Data.Interface
{
    public interface IBookRepository
    {
        public IEnumerable<Book> OphalenBoekenMetZoekterm(string boekZoekterm,string publisherZoekterm);



    }
}
