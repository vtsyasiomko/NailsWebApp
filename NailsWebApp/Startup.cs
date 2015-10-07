using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NailsWebApp.Startup))]
namespace NailsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
