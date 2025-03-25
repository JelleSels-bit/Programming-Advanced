using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Publishers.Data.Repository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public IEnumerable<Book> OphalenBoekenMetZoekterm(string boekZoekterm, string publisherZoekterm, string auteurZoekterm)
        {
            var sql = @"SELECT B.*, '' AS SplitCol, P.*, '' AS SplitCol, A.*
                        FROM Book B
                        LEFT JOIN Publisher P ON B.PublisherId = P.id
                        JOIN TitleAuthor Ta ON Ta.bookId = B.id
                        JOIN Author A ON Ta.authorId = A.id
                        WHERE P.name LIKE '%'+ @publisher +'%'
                        AND
                        B.Title LIKE '%'+ @title +'%'
                        AND
                        (A.firstName LIKE '%'+ @name +'%' OR A.lastName LIKE '%'+ @name +'%' )
                        ORDER BY B.releaseDate";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var boeken = db.Query<Book, Publisher, Author, Book>(
                    sql,
                    (title, publisher, author) =>
                    {
                        title.Publisher = publisher;
                        title.Authors = [author];
                        return title;
                    },
                    new { publisher = publisherZoekterm, title = boekZoekterm, name = auteurZoekterm }, splitOn: "SplitCol"
                );

                return GroepeerBoeken(boeken);
            }
        }

        private static IEnumerable<Book> GroepeerBoeken(IEnumerable<Book> boeken)
        {
            var gegroepeerd = boeken.GroupBy(boek => boek.Title);

            List<Book> boekenMetAuteurs = new List<Book>();

            foreach (var groep in gegroepeerd)
            {
                var boek = groep.First();
                List<Author> alleAuteurs = new List<Author>();

                foreach (var b in groep)
                {
                    alleAuteurs.Add(b.Authors.First());
                }

                boek.Authors = alleAuteurs;
                boekenMetAuteurs.Add(boek);
            }

            return boekenMetAuteurs;
        }




    }
}
