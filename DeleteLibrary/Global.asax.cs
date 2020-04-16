using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DeleteLibrary.Context;
using DeleteLibrary.Interfaces;
using DeleteLibrary.Services;
using LightInject;

namespace DeleteLibrary
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new ServiceContainer();
            container.RegisterControllers();
            //Database.SetInitializer(new LibraryDbInit());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            container.Register<IlibraryService, EnityLibraryService>(new PerRequestLifeTime());
            container.EnableMvc();
        }
    }
}
