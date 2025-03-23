using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Models
{
    public class Sale
    {
        public Store Store { get; set; }
        public Book Book { get; set; }

        public override string ToString()
        {
            return $"{Store.Name} {Store.Address} {Book.VerkoopDatum} {Book.aantalBoek}";
        }
    }
}
