using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NailsWebApp.Data.Common;
using NailsWebApp.Data.DAL;

namespace NailsWebApp.Data.Nails
{
    public class NailsDbContext : GenericPortalContext, INailsDbContext
    {
        public NailsDbContext(string connectionString) 
            : base(new AppNailsDbContext(connectionString))
        {
            
        }
    }
}
