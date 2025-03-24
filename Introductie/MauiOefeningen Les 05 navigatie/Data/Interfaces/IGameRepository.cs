using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOefeningen.Data.Interfaces
{
    public interface IGameRepository
    {
        public List<Game> GetGames();
    }
}
