using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publishers.Models;

namespace Publishers.Data.Interface
{
    public interface IEmployeeInterface
    {
        public IEnumerable<Employee> WerknemersOphalen();
        public List<Employee> WerknemersOphalenViaJob(int jobId);
        public List<Employee> WerknemersOphalenViaPublisher(int publisherId);
        public List<Employee> WerknemersOphalenViaJobEnPublisher(int jobId, int publisherId);
        public List<Employee> WerknemersOphalenViaHireDate(DateTime hireDate);
        public Employee WerknemerOphalenViaId(int id);

    }
}
