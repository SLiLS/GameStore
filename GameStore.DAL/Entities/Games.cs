using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GameStore.DAL.Entities
{
  public  class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public string GameCategory { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
