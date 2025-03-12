using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publishers.Data.Interfaces;
using Publishers.Models;

namespace Publishers.Data.Repositories
{
    public class StoreRepository : BaseRepository, IStoreRepository
    {
        public List<Store> OphalenStoresViaNaam(string naam)
        {
            string sql = @"SELECT *";
            sql += " FROM Store";
            sql += " WHERE name LIKE '%'+ @naam +'%'";
            sql += "ORDER BY name ASC";
            

            var parameters = new { @naam = naam};
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }

        public List<Store> OphalenStoresViaNaamEnStaat(string naam, string staat)
        {
            string sql = @"SELECT *";
            sql += " FROM Store";
            sql += " WHERE name LIKE '%'+ @naam +'%'";
            sql += " AND state LIKE '%' + @state + '%' ";
            sql += " ORDER BY name ASC";

            var parameters = new { @naam = naam, @state = staat };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }

        public List<Store> OphalenStoresViaStaat(string staat)
        {
            string sql = @"SELECT *";
            sql += " FROM Store";
            sql += " WHERE state LIKE '%' + @state + '%' ";
            sql += " ORDER BY state ASC";

            var parameters = new { @state = staat };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }

        public Store OphalenStoreViaId(int id)
        {
            string sql = @"SELECT *";
            sql += " FROM Store";
            sql += " WHERE id = @Id ";
          

            var parameters = new { @Id = id};
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QuerySingleOrDefault<Store>(sql,parameters);
            }
        }
    }
}
