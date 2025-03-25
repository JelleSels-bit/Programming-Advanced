using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publishers.Models;

namespace Publishers.Data.Interface
{
    public interface IPublishersRepository
    {
        public IEnumerable<Publisher> OphalenPublishers();
    }
}
