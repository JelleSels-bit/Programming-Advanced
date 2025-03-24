using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOefeningen.Models
{
    public class Functie
    {
        public string Naam { get; set; }

        public override string ToString()
        {
            return Naam;
        }
        public override bool Equals(object? obj)
        {
            return obj is Functie functie && functie.Naam == Naam;
        }
    }
}
