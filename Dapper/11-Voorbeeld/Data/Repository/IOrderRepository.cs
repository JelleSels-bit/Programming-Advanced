using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Models;

namespace Orders.Data.Repository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> OrdersOphalen();

        public IEnumerable<Order> OrdersOphalenVoorKlant(string bedrijfsnaam);
        bool ToevoegenOrder(Order order);
        bool WijzigenOrder(Order order);
        bool VerwijderenOrder(int id);
    }
}