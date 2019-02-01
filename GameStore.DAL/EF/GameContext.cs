using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GameStore.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;    

namespace GameStore.DAL.EF
{
    public   class GameContext :IdentityDbContext<ApplicationUser>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
  

        public GameContext()
            :base("GameStore")
        {

        }
           
    }
}
