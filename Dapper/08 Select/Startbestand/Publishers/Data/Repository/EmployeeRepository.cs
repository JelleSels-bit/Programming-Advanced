using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publishers.Data.Interface;
using Publishers.Models;

namespace Publishers.Data.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeInterface
    {
        public IEnumerable<Employee> WerknemersOphalen()
        {
            string sql = @"SELECT *";
            sql += " FROM Employee";
            sql += " ORDER BY lastName, firstName";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql);
            }
        }
        public Employee WerknemerOphalenViaId(int id)
        {
            string sql = @"SELECT *";
            sql += " FROM Employee";
            sql += " WHERE id = @id";


            var parameters = new { @id = id };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QuerySingleOrDefault<Employee>(sql, parameters);
            }
        }

        public List<Employee> WerknemersOphalenViaHireDate(DateTime hireDate)
        {
            string sql = @"SELECT *";
            sql += " FROM Employee";
            sql += " WHERE hireDate <= @hireDate";
            sql += " ORDER BY lastName, firstName";

            var parameters = new { @hireDate = hireDate };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql,parameters).ToList();
            }
        }

        public List<Employee> WerknemersOphalenViaJob(int jobId)
        {
            string sql = @"SELECT *";
            sql += " FROM Employee";
            sql += " WHERE jobId = @jobId";
            sql += " ORDER BY lastName,firstName";

            var parameters = new { @jobId = jobId };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).ToList();
            }
        }

        public List<Employee> WerknemersOphalenViaPublisher(int publisherId)
        {
            string sql = @"SELECT *";
            sql += " FROM Employee";
            sql += " WHERE publisherId = @publisherId";
            sql += " ORDER BY lastName,firstName";

            var parameters = new { @publisherId = publisherId };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).ToList();
            }
        }

        public List<Employee> WerknemersOphalenViaJobEnPublisher(int jobId, int publisherId)
        {
            string sql = @"SELECT *";
            sql += " FROM Employee";
            sql += " WHERE jobId = @jobId";
            sql += " AND publisherId = @publisherId";
            sql += " ORDER BY lastName,firstName";

            var parameters = new { @jobId = jobId, @publisherId = publisherId };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).ToList();
            }
        }


    
    }
}
