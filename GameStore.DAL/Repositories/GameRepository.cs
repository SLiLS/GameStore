using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using GameStore.DAL.EF;
using System.Data.Entity;

namespace GameStore.DAL.Repositories
{
   public class GameRepository  : IRepository<Game>
    {
        GameContext db;
        public GameRepository(GameContext context)
        {
            db = context;
        }
        public IEnumerable<Game> GetAll()
        {
            return db.Games;
        }
        public Game Get(int id)
        {
            return db.Games.Find(id);
        }
        public void Create(Game item)
        {
            db.Games.Add(item);
            db.SaveChanges();
        }
        public void Update(Game item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Game> Find(Func<Game,Boolean> predicate)
        {
            return db.Games.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
        }
    }
}
