using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GameStore.DAL.EF;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using GameStore.DAL.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GameStore.DAL.Repositories
{
   public class EFUnitOfWork : IUnitOfWork
    {
        private GameContext db;
        private GameRepository gameRepository;
        private OrderRepository orderRepository;
        //private CartRepository cartRepository;
        private RequirementRepository requirementRepository;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        //private IClientManager clientManager;



        public EFUnitOfWork()
        {
            db = new GameContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            //clientManager = new ClientManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        //public IClientManager ClientManager
        //{
        //    get { return clientManager; }
        //}

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

       
       
        public IGameRepository Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(db);
                return gameRepository;
            }
        }
        public IRequirementRepository Requirements
        {
            get
            {
                if (requirementRepository == null)
                    requirementRepository = new RequirementRepository(db);
                return requirementRepository;
            }
        }
        //public ICartRepository Carts
        //{
        //    get
        //    {
        //        if (cartRepository == null)
        //            cartRepository = new CartRepository(db);
        //        return cartRepository;
        //    }
        //}

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
