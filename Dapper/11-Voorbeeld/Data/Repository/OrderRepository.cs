﻿using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Orders.Models;

namespace Orders.Data.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public IEnumerable<Order> OrdersOphalen()
        {
            // De volgorde van de tabellen is belangrijk!
            // Hier is de volgorde: Orders, Klanten, Werknemers
            // Dapper krijgt de records binnen zoals in de lessen SQL, als rijen tekst met veel duplicatie.
            // Om de mapping naar objecten te maken, moet Dapper weten welke kolommen overeenkomen met
            // welke klassen in de models.
            string sql = @"SELECT TOP 10 O.*, K.*, W.*
                           FROM Orders O
                           INNER JOIN Klanten K ON O.KlantId = K.Id
                           INNER JOIN Werknemers W ON O.WerknemerID = W.Id";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                // De Volgorde van de parameters in de Query functie moet
                // dezelfde volgorde zijn als hierboven.
                // Hier geven de parameters aan dat we in het tweede argument een
                // functie moeten meegeven die een Order, Klant en Werknemer als
                // argument krijgt, en een Order teruggeeft.
                var debugVar = db.Query<Order, Klant, Werknemer, Order>(
                    sql,
                    (order, klant, werknemer) =>
                    {
                        order.Klant = klant;
                        order.Werknemer = werknemer;
                        return order;
                    },
                    splitOn: "Id"
                );
                // De debugVar is enkel toegevoegd om een breakpunt te kunnen zetten
                // en de inhoud van de variabele te kunnen bekijken.
                return debugVar;
            }
        }

        public IEnumerable<Order> OrdersOphalenVoorKlant(string bedrijfsnaam)
        {
            string sql = @"SELECT O.*, K.*, W.*
                           FROM Orders O
                           INNER JOIN Klanten K ON O.KlantId = K.Id
                           INNER JOIN Werknemers W ON O.WerknemerId = W.Id
                           WHERE K.Bedrijf LIKE '%' + @bedrijfsnaam + '%'";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Order, Klant, Werknemer, Order>(
                    sql,
                    (order, klant, werknemer) =>
                    {
                        order.Klant = klant;
                        order.Werknemer = werknemer;
                        return order;
                    },
                    new { bedrijfsnaam = bedrijfsnaam }
                );
            }
        }

        public bool ToevoegenOrder(Order order)
        {
            string sql = @"INSERT INTO Orders (klantId, werknemerId, orderdatum, verzendadres, verzendplaats, verzendpostcode, verzendland)
               VALUES (@klantId, @werknemerId, @orderdatum, @verzendadres, @verzendplaats, @verzendpostcode, @verzendland)";

            var parameters = new
            {
                klantId = order.Klant.Id,
                werknemerId = order.Werknemer.Id,
                orderdatum = order.Orderdatum,
                verzendadres = order.Verzendadres,
                verzendplaats = order.Verzendplaats,
                verzendpostcode = order.Verzendpostcode,
                verzendland = order.Verzendland
            };

            using IDbConnection db = new SqlConnection(ConnectionString);
            var affectedRows = db.Execute(sql, parameters);

            return affectedRows >= 1;
        }

        public bool VerwijderenOrder(int id)
        {
            string sql = @"DELETE FROM Orderlijnen WHERE OrderId = @id;
            DELETE FROM Orders WHERE Id = @id";

            using IDbConnection db = new SqlConnection(ConnectionString);
            var affectedRows = db.Execute(sql, new { id = id });

            return affectedRows >= 1;
        }

        public bool WijzigenOrder(Order order)
        {
            string sql = @"UPDATE Orders
                           SET klantId = @klantId,
                               werknemerId = @werknemerId,
                               orderdatum = @orderdatum,
                               verzendadres = @verzendadres,
                               verzendplaats = @verzendplaats,
                               verzendpostcode = @verzendpostcode,
                               verzendland = @verzendland
                           WHERE Id = @id";

            var parameters = new
            {
                id = order.Id,
                klantId = order.Klant.Id,
                werknemerId = order.Werknemer.Id,
                orderdatum = order.Orderdatum,
                verzendadres = order.Verzendadres,
                verzendplaats = order.Verzendplaats,
                verzendpostcode = order.Verzendpostcode,
                verzendland = order.Verzendland
            };

            using IDbConnection db = new SqlConnection(ConnectionString);
            var affectedRows = db.Execute(sql, parameters);

            return affectedRows >= 1;
        }
    }
}