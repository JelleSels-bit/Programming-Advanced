using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publishers.Data.Interface;
using Publishers.Models;

namespace Publishers.Data.Repository
{
    public class StoresRepository : BaseRepository, IStoresRepository
    {
        

        public List<Store> OphalenViaNaam(string naam)
        {
            string sql = @"SELECT *";
            sql += " FROM Store";
            sql += " WHERE name like '%'+ @name +'%'";
            sql += " ORDER BY name";

            var parameters = new { @name = naam  };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }

        public List<Store> OphalenViaStaat(string staat)
        {
            string sql = @"SELECT *";
            sql += " FROM Store";
            sql += " WHERE state like '%'+ @state +'%'";
            sql += " ORDER BY state";

            var parameters = new { @state = staat };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }

        public List<Store> OphalenViaStaatEnNaam(string naam, string staat)
        {
            string sql = @"SELECT *";
            sql += " FROM Store";
            sql += " WHERE name like '%'+ @name +'%'";
            sql += " AND state like '%'+ @state +'%'";
            sql += " ORDER BY name,state";

            var parameters = new { @name = naam , @state = staat };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }

        }
        public Store OphalenViaId(int id)
        {
            string sql = @"SELECT *";
            sql += " FROM Store";
            sql += " WHERE id = @id";
            

            var parameters = new { @id = id };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QuerySingleOrDefault<Store>(sql, parameters);
            }
        }
    }
}
