using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publishers.Models;

namespace Publishers.Data.Interface
{
    public interface IStoresRepository
    {
        public List<Store> OphalenViaNaam(string naam);
        public List<Store> OphalenViaStaat(string staat);
        public List<Store> OphalenViaStaatEnNaam(string naam, string staat);
        public Store OphalenViaId(int id);
    }
}
