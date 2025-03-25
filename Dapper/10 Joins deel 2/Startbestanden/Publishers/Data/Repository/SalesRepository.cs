using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Data.Repository
{
    public class SalesRepository : BaseRepository, ISalesRepository
    {
        public IEnumerable<Sale> OphalenSalesVoorBoeken(int bookId)
        {
            var sql = @"SELECT S.*,B.*,St.*
                        FROM Sale S
                        JOIN Book B ON S.bookId = B.id
                        JOIN Store St ON s.storeId = St.id
                        WHERE B.id = @bookId
                        ORDER BY B.releaseDate";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Sale, Book, Store,Sale>(
                    sql,
                    (sale, book, store) =>
                    {
                        sale.Book = book;   
                        sale.Store = store;
                        return sale;
                    },
                    new { bookId = bookId}
                ).ToList();
            }
        }

        public IEnumerable<Sale> OphalenSalesVoorPublisher(int publisherId)
        {
            var sql = @"SELECT S.*, B.*, St.*
                        FROM Sale S
                        JOIN Book B ON S.bookId = B.id
                        JOIN Store St ON s.storeId = St.id
                        WHERE B.publisherId = @publisherId
                        ORDER BY B.releaseDate";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Sale, Book, Store, Sale>(
                    sql,
                    (sale, book, store) =>
                    {
                        sale.Book = book;
                        sale.Store = store;
                        return sale;
                    },
                    new { publisherId = publisherId }
                ).ToList();
            }
        }
    }
}
