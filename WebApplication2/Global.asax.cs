using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebApplication2.Data;
using WebApplication2.Repository.IRepository;
using WebApplication2.Repository.Repositories;
using WebApplication2.Service.IService;
using WebApplication2.Service.Services;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);



            builder.RegisterType<PesaPalRepository>().As<IPesaPalRepository>();
            builder.RegisterType<PeopleRepository>().As<IPeopleRepository>();
            builder.RegisterType<PesaPalService>().As<IPesaPalService>();
            builder.RegisterType<WebApplication2Context>();
            builder.RegisterType<PesaPalHttpClient>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}
