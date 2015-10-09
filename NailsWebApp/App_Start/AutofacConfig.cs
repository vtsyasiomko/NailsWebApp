using System.Configuration;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NailsApp.Common.Modules;
using NailsApp.Data;
using NailsApp.Services;

namespace NailsApp.Web
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