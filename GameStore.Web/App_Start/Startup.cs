using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using GameStore.BLL.Services;
using Microsoft.Owin.Security.Cookies;
using GameStore.BLL.Interfaces;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(GameStore.Web.App_Start.Startup))]

namespace GameStore.Web.App_Start
{
    public class Startup
    {
       
        public void Configuration(IAppBuilder app)
        {
           
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

      
    }
}