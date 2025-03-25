using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publishers.Data.Interface;
using Publishers.Models;

namespace Publishers.Data.Repository
{
    public class PublisherRepository : BaseRepository, IPublishersRepository
    {
        public IEnumerable<Publisher> OphalenPublishers()
        {
            string sql = @"SELECT *";
            sql += " FROM Publisher";
            sql += " ORDER BY name";



            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Publisher>(sql).ToList();
            }
        }
    }
}
