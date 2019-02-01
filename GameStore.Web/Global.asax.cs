using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using Ninject.Modules;
using Ninject;
using GameStore.BLL.Infrastructure;
using GameStore.Web.Util;
using System.Web.Routing;
using Ninject.Web.Mvc;


namespace GameStore.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule orderModule = new OrderModule();
            ServiceModule serviceModule = new ServiceModule();
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            kernel.Unbind<ModelValidatorProvider>();
           

        }
    }
}
