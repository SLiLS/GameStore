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
   public class RequirementRepository :IRequirementRepository
    {
        GameContext db;

        public RequirementRepository(GameContext context)
        {
            db = context;
        }
        public IEnumerable<Requirement> GetAll()
        {
            return db.Requirements;
        }

        public Requirement Get(int? id)
        {
            return db.Requirements.Where(i => i.Id == id).FirstOrDefault();
        }
        public void Create(Requirement item)
        {
            db.Requirements.Add(item);

        }
        public void Update(Requirement item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
 
        public void Delete(int id)
        {
            Requirement item = db.Requirements.Find(id);
            db.Requirements.Remove(item);
        }

    }
}
