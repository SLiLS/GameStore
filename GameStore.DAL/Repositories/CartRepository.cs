using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using System.Data.Entity;
using GameStore.DAL.EF;

namespace GameStore.DAL.Repositories
{
   public class CartRepository : ICartRepository
    {
        GameContext db;

        public CartRepository(GameContext context)
        {
            db = context;
        }
        public void AddToCart(Game game, string Id)
        {
            Cart cart = db.Carts.Where(c => c.ClientCartId == Id && c.GameId == game.Id).FirstOrDefault();

            if (cart != null)
            {
                cart.Sum++;
            }
            else
            {
                db.Carts.Add(new Cart { ClientCartId = Id, GameId = game.Id, Sum = 1 });

            }


        }




        public IEnumerable<Cart> GetAll(string Id)
        {
            return db.Carts.Where(c => c.ClientCartId == Id).Include(b => b.Game);
        }

        public void Remove(Game game, string Id)
        {
            Cart cart = db.Carts.Where(b => b.ClientCartId == Id && b.Game.Id == game.Id).FirstOrDefault();
            if (cart != null)
            {
                db.Carts.Remove(cart);
            }

        }

    }
}
