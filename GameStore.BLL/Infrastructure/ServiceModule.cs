﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Interfaces;
using GameStore.DAL.Repositories;
using Ninject.Modules;

namespace GameStore.BLL.Infrastructure
{
 public   class ServiceModule :NinjectModule
    {
        
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
