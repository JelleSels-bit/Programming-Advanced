using Dapper;
using Publishers.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Publishers.Data.Interface;

namespace Publishers.Data.Repository
{
    public class PublishersRepository : BaseRepository, IPublishersRepository
    {
        public IEnumerable<Publisher> OphalenPublishers()
        {
            string sql = "SELECT * FROM Publisher ORDER BY name";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Publisher>(sql);
            }
        }

        // Hier was enkel gevraagd om de uitgever te geven die aan de zoekterm voldeden.
        //public IEnumerable<Publisher> OphalenPublishers(string zoekterm)
        //{
        //    string sql = "SELECT * FROM Publisher WHERE name LIKE '%' + @zoekterm +'%' ORDER BY name";
        //    var parameters = new { @zoekterm = zoekterm };
        //    using (IDbConnection db = new SqlConnection(ConnectionString))
        //    {
        //        return db.Query<Publisher>(sql,parameters).ToList();
        //    }
        //}

        public IEnumerable<Publisher> OphalenPublishers(string zoekterm)
        {
            string sql = @"SELECT P.*, '' AS SplitCol, B.*, '' AS SplitCol, A.*
                    FROM Publisher P
                    LEFT JOIN Book B on P.Id = B.publisherId
                    LEFT JOIN TitleAuthor TA on B.Id = TA.bookId
                    LEFT JOIN Author A on A.Id = TA.authorId                                
                    WHERE name LIKE '%' + @zoekterm + '%' ORDER BY name";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var publishers = db.Query<Publisher, Book, Author, Publisher>(sql,
                    (publisher, book, author) =>
                    {
                        book.Publisher = publisher;
                        book.Authors = [author];
                        publisher.Books = [book];

                        return publisher;
                    }, new { zoekterm = zoekterm }, splitOn: "SplitCol");

                var gegroepeerdePublishers = GroepeerPublishers(publishers);

                return gegroepeerdePublishers.Select(p =>
                {
                    p.Books = GroepeerBooks(p.Books);
                    return p;
                });
            }
        }
        private static ICollection<Publisher> GroepeerPublishers(IEnumerable<Publisher> Publishers)
        {
            var gegroepeerd = Publishers.GroupBy(p => p.Id);
            return gegroepeerd.Select(g =>
            {
                var publisher = g.First();
                publisher.Books = g.Select(k => k.Books.Single()).ToList();
                return publisher;
            }).ToList();
        }

        private static List<Book> GroepeerBooks(IEnumerable<Book> books)
        {
            var gegroepeerd = books.GroupBy(p => p.Id);
            return gegroepeerd.Select(g =>
            {
                var book = g.First();
                book.Authors = g.Select(p => p.Authors.Single()).ToList();
                return book;
            }).ToList();
        }



    }
}