using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GameStore.DAL.Identity
{
   public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
            : base (store)
        {

        }
    }
}
