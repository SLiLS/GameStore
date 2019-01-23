﻿using System;
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
   public class GameRepository  : IGameRepository
    {
        GameContext db;
      
        public GameRepository(GameContext context)
        {
            db = context;
        }
        public  IEnumerable<Game> GetAll()
        {
            return db.Games;
        }
     
        public Game Get(int? id)
        {
            return db.Games.Where(i => i.Id == id).Include(r => r.Requirement).FirstOrDefault();
        }
        public void Create(Game item)
        {
            db.Games.Add(item);
            
           
        }
        public void Update(Game item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Game> FindGames(string searchtext)
        {
            List<Game> games = new List<Game>();
            games.AddRange(db.Games.Where(b => b.GameName.Contains(searchtext)).Include(v => v.Requirement));
            games.AddRange(db.Games.Where(b => b.GameCategory.Contains(searchtext)).Include(v => v.Requirement));
            return games;
        }
        public void Delete(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
        }
    }
}
