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
        public IEnumerable<Cart> GetAll()
        {
            return db.Carts;
        }
        public Cart Get(int? id)
        {
            return  db.Carts.Find(id);
        }
        public void Create(Cart item)
        {
            db.Carts.Add(item);

        }
        public void Update(Cart item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
       
        public void Delete(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
        }
    }
}
