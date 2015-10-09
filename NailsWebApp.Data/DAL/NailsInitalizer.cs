using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsApp.Data.DAL
{
    public class NailsInitalizer : System.Data.Entity.CreateDatabaseIfNotExists<AppNailsDbContext>
    {
        protected override void Seed(AppNailsDbContext context)
        {

        }
    }
}
