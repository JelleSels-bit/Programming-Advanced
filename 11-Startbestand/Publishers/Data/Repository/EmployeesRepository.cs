﻿using Publishers.Data.Interface;
using Publishers.Models;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Employee> OphalenEmployeesMetUitgeverEnJob()
        {
            var sql = @"SELECT E.*, P.*, J.*
                        FROM Employee E
                        JOIN Publisher P ON E.publisherId = P.id
                        JOIN Job J ON E.jobId = J.id
                        ORDER BY E.firstName, E.lastName";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee, Publisher, Job, Employee>(
                    sql,
                    (employee, publisher, job) =>
                    {
                        employee.Job = job;
                        employee.Publisher = publisher;
                        return employee;
                    }
                    ).ToList();
            }
        }

        public bool ToevoegenEmployee(Employee employee)
        {
            string sql = @"INSERT INTO Publishers (code, firstName, lastName, jobId, publisherId, hireDate )
               VALUES (@code, @firstName, @lastName, @jobId, @jobLevel, @publisherId, @hireDate)";

            var parameters = new
            {
                code = employee.Code,
                firstName = employee.FirstName,
                lastName = employee.LastName,
                jobId = employee.JobId,
                jobLevel = employee.JobLevel,
                publisherId = employee.PublisherId,
                hireDate = employee.HireDate
                
            };

            using IDbConnection db = new SqlConnection(ConnectionString);
            var affectedRows = db.Execute(sql, parameters);

            return affectedRows >= 1;
        }

        public bool VerwijderenEmployee(int id)
        {
            string sql = @"DELETE FROM Employee WHERE Id = @id;
            DELETE FROM Orders WHERE Id = @id";

            using IDbConnection db = new SqlConnection(ConnectionString);
            var affectedRows = db.Execute(sql, new { id = id });

            return affectedRows >= 1;
        }

        public bool WijzigenEmployee(Employee employee)
        {
            string sql = @"UPDATE INTO Publishers (code, firstName, lastName, jobId, publisherId, hireDate )
               VALUES (@code, @firstName, @lastName, @jobId, @jobLevel, @publisherId, @hireDate)";

            var parameters = new
            {
                code = employee.Code,
                firstName = employee.FirstName,
                lastName = employee.LastName,
                jobId = employee.JobId,
                jobLevel = employee.JobLevel,
                publisherId = employee.PublisherId,
                hireDate = employee.HireDate
            };

            using IDbConnection db = new SqlConnection(ConnectionString);
            var affectedRows = db.Execute(sql, parameters);

            return affectedRows >= 1;
        }





    }
}