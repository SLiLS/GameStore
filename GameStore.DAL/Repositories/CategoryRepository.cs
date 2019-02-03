using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameStore.DAL.Entities;
using System.Threading.Tasks;
using GameStore.DAL.Interfaces;
using GameStore.DAL.EF;
using System.Data.Entity;

namespace GameStore.DAL.Repositories
{
  public  class CategoryRepository : ICategoryRepository
    {
        GameContext db;

        public CategoryRepository(GameContext context)
        {
            db = context;
        }
        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category Get(int? id)
        {
            return db.Categories.Where(i => i.Id == id).FirstOrDefault();
        }
        public void Create(Category item)
        {
            db.Categories.Add(item);


        }
        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
       
        public void Delete(int id)
        {
            Category item = db.Categories.Find(id);
            if(item!=null)
            db.Categories.Remove(item);
        }
    }
}
