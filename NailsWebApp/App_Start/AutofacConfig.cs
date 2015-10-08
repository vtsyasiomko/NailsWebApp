using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using NailsWebApp.Common.Modules;
using NailsWebApp.Data;
using NailsWebApp.Data.DAL;
using NailsWebApp.Data.Models.Identity;
using NailsWebApp.Services;
using Owin;

namespace NailsWebApp.App_Start
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainerWebApi()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(AutofacConfig).Assembly).PropertiesAutowired();

            builder.RegisterSource(new ViewRegistrationSource());

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register our Data dependencies
            builder.RegisterModule(new DataModule(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            //builder.RegisterModule(new MvcSiteMapProviderModule());

            // Register Common module
            builder.RegisterModule(new CommonModule());

            builder.RegisterModule(new ServiceModule());

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // Set MVC DI resolver to use our Autofac container
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}