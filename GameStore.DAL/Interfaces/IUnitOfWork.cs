using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameStore.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using GameStore.DAL.EF;
using GameStore.DAL.Identity;

namespace GameStore.DAL.Interfaces
{
  public  interface IUnitOfWork : IDisposable
    {
        IGameRepository Games { get; }
        IRepository<Order> Orders { get;  }
        ICartRepository Carts { get; }
        IRequirementRepository Requirements { get; }


        //IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        ApplicationUserManager UserManager { get; }

        void Save();
        Task SaveAsync();
    }
}
