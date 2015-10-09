using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsApp.Data.Models
{
    public class Street
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string OldStreetName { get; set; }

        public virtual City City { get; set; }

    }
}
