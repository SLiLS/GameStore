﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entities;

namespace GameStore.DAL.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> FindGames(string searchtext);
    }
}
