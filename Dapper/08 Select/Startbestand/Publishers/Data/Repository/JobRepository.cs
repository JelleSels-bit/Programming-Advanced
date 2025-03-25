using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publishers.Data.Interface;
using Publishers.Models;

namespace Publishers.Data.Repository
{
    public class JobRepository : BaseRepository, IJobRepository
    {
        public IEnumerable<Job> OphalenJobs()
        {
            string sql = @"SELECT *";
            sql += " FROM Job";
            sql += " ORDER BY description";

            

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Job>(sql).ToList();
            }
        }
    }
}
