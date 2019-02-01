using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameStore.DAL.Entities;
using System.Threading.Tasks;

namespace GameStore.DAL.Interfaces
{
  public  interface ICartRepository 
    {
        void AddToCart(Game item, string Id);
        IEnumerable<Cart> GetAll(string Id);
        void Remove(Game game, string Id);



    }
}
