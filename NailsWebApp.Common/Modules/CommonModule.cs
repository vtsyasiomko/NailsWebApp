using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NailsApp.Common.Mapping;

namespace NailsApp.Common.Modules
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MappingService>()
                   .As<IMappingService>()
                   .SingleInstance();
        }
    }
}
