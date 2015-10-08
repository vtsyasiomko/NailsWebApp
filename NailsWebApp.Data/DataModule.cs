using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NailsWebApp.Data.Common;
using NailsWebApp.Data.DAL;
using NailsWebApp.Data.Nails;

namespace NailsWebApp.Data
{
    public class DataModule : Module
    {
        private readonly string _nailsNameOrConnection;

        public DataModule(string nailsNameOrConnection)
        {
            _nailsNameOrConnection = nailsNameOrConnection;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new NailsDbContext(_nailsNameOrConnection))
                   .As<INailsDbContext>()
                   .InstancePerRequest();

            builder.Register(c => new ApplicationDbContext(_nailsNameOrConnection))
                   .AsSelf()
                   .InstancePerRequest();

            builder.RegisterGeneric(typeof(Repository<,>))
                   .As(typeof(IRepository<,>))
                   .InstancePerRequest();

            base.Load(builder);
        }
    }
}
