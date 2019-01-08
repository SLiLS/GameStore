using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Services;

namespace GameStore.Web.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}