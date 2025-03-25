using Publishers.Data.Interface;
using Publishers.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Publishers.Data.Repository
{
    public class EmployeesRepository : BaseRepository, IEmployeesRepository
    {
        public IEnumerable<Employee> OphalenEmployees()
        {
            string sql = "SELECT * FROM Employee ORDER BY lastName, firstName";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql);
            }
        }

        public List<Employee> OphalenEmployeesViaUitgeverenEnJob(string uitgever)
        {
            var sql = @"SELECT E.*, P.*, J.* 
                        FROM Employee E
                        JOIN Publisher P ON E.PublisherId = P.id
                        JOIN Job J on E.jobId = J.id 
                        WHERE P.name LIKE '%'+ @uitgever +'%'
                        ORDER BY E.firstName, E.lastName";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee, Publisher,Job, Employee>(
                    sql,
                    (employee, publisher,job) =>
                    {
                        employee.Publisher = publisher;
                        employee.Job = job;
                        return employee;
                    },
                    new { uitgever = uitgever}
                ).ToList();
            }
        }

        public List<Employee> OphalenEmployeesViaHireDate(DateTime hiredate)
        {
            string sql = "SELECT * FROM Employee WHERE hireDate <= @hiredate ORDER BY lastName, firstName";
            var parameters = new { @hiredate = hiredate };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).AsList();
            }
        }

        public List<Employee> OphalenEmployeesViaJobId(int id)
        {
            string sql = "SELECT * FROM Employee WHERE jobId = @jobId ORDER BY lastName, firstName";
            var parameters = new { @jobId = id };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).AsList();
            }
        }

        public List<Employee> OphalenEmployeesViaPublisherId(int id)
        {
            string sql = "SELECT * FROM Employee WHERE publisherId = @id ORDER BY lastName, firstName";
            var parameters = new { @id = id };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).AsList();
            }
        }

        public List<Employee> OphalenEmployeesViaPublisheridEnJobid(int pubId, int jobId)
        {
            string sql = "SELECT * FROM Employee " +
                "WHERE publisherId = @pubId " +
                "AND (@jobId = jobId OR @jobId=0) " +
                "ORDER BY lastName, firstName";
            var parameters = new { @pubId = pubId, @jobId = jobId };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).AsList();
            }
        }

        

        public Employee OphalenEmployeeViaId(int id)
        {
            string sql = "SELECT * FROM Employee WHERE id = @id";
            var parameters = new { @id = id };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QuerySingleOrDefault<Employee>(sql, parameters);
            }
        }

        
    }
}