using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NailsApp.Data.Common;
using NailsApp.Data.DAL;

namespace NailsApp.Data.Nails
{
    public class NailsDbContext : GenericPortalContext, INailsDbContext
    {
        public NailsDbContext(string connectionString) 
            : base(new AppNailsDbContext(connectionString))
        {
            
        }
    }
}
