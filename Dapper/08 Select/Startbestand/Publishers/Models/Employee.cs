using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string code { get; set; }    
        public string firstName {  get; set; }
        public string lastName { get; set; }
        public int jobId { get; set; }
        public int jobLevel { get; set;}
        public int publisherId { get ; set; }
        public DateTime HireDate { get; set; }

        public string FullName => $"{firstName} {lastName}";

        public Publisher publisher;
        public Job job;



        
    }
}
