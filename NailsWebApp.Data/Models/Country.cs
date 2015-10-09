using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsApp.Data.Models
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
        public string CountryName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<City> Cities { get; set; }

    }
}
