using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Interfaces;
using GameStore.DAL.Entities;
using GameStore.DAL.EF;

namespace GameStore.DAL.Repositories
{
    public class ClientManager /*: IClientManager*/
    {
        public GameContext Database { get; set; }
        //public ClientManager(GameContext db)
        //{
        //    Database = db;
        //}

        //public void Create(ClientProfile item)
        //{
        //    Database.ClientProfiles.Add(item);
        //    Database.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    Database.Dispose();
        //}
    }
}
