using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GameStore.DAL.EF;
using GameStore.DAL.Interfaces;
using GameStore.DAL.Entities;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories
{
  public  class OrderRepository :IRepository<Order>
    {
        GameContext db;
        public OrderRepository(GameContext context)
        {
            db = context;
        }
        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }
        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
           
        }
        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
        }
    }
}
