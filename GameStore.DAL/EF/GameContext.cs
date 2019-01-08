using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GameStore.DAL.Entities;
namespace GameStore.DAL.EF
{
    public   class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Order> Orders { get; set; }

        static GameContext  ()
            
        {
            Database.SetInitializer<GameContext>(new Initializer());
        }
      public GameContext(string connectionstring)
            :base(connectionstring)
        {

        }
           
    }
}
