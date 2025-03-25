using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Publishers.Data.Repository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public IEnumerable<Book> OphalenBoekenMetZoekterm(string boekZoekterm,string publisherZoekterm)
        {
            var sql = @"SELECT B.*, P.* 
                        FROM Book B
                        JOIN Publisher P ON B.PublisherId = P.id
                        WHERE P.name LIKE '%'+ @publisher +'%'
                        AND
                        B.Title LIKE '%'+ @book +'%'
                        ORDER BY B.releaseDate";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Book, Publisher, Book>(
                    sql,
                    (book, publisher ) =>
                    {
                        book.Publisher = publisher;
                        return book;
                    },
                    new { publisher = publisherZoekterm, book = boekZoekterm }
                ).ToList();
            }
        }
    }
}
