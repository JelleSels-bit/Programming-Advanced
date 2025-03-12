using Publishers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publishers.Data.Repository
{
    public interface IPublishersRepository
    {
        public IEnumerable<Publisher> OphalenPublishers();
    }
}