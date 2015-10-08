using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Module = Autofac.Module;

namespace NailsWebApp.Services
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType(typeof(ProgrammListService))
            //    .As(typeof(IProgrammListService))
            //    .InstancePerRequest();
        }
    }
}
