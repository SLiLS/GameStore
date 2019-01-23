using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace GameStore.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager (IUserStore<ApplicationUser> store)
            : base(store)
        {

        }
    }
}
