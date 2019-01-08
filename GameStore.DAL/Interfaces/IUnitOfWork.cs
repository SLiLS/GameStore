using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameStore.DAL.Entities;
using System.Threading.Tasks;

namespace GameStore.DAL.Interfaces
{
  public  interface IUnitOfWork : IDisposable
    {
        IRepository<Game> Games { get;  }
        IRepository<Order> Orders { get;  }
        void Save();
    }
}
