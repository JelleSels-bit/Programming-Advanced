using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOefeningen.Data.Repositories
{
    internal class FunctieRepository : IFunctieRepository
    {
        public List<Functie> Functies = new()
        {
            new Functie() { Naam = "Manager" },
            new Functie() { Naam = "Developer" },
            new Functie() { Naam = "Designer" }
        };
        public List<Functie> GetFuncties()
        {
            return Functies;
        }

       
    }
}
