﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JobId { get; set; }
        public byte JobLevel { get; set; }
        public int PublisherId { get; set; }
        public DateTime HireDate { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Publisher Publisher { get; set; }
        public Job Job { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Publisher} {Job.Description}";
        }
    }
}