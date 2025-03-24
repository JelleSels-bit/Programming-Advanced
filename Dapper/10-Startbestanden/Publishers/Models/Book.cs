﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public double Price { get; set; }
        public double Advance { get; set; }
        public int Royalty { get; set; }
        public int Sales { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Publisher Publisher { get; set; }

        public List<Author> Authors { get; set; }

        public string AuthorInfo()
        {
            string result = "Geschreven door: \n";

            foreach (Author author in Authors )
            {
             result += $"{author.Name} \n";   
            }
            return result;
        }
        public override string ToString()
        {
            return $"{Title}\nUitgever: {Publisher}\nUitgave datum: {ReleaseDate.ToShortDateString()}";
        }
    }
}
