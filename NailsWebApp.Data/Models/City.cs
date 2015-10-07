using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsWebApp.Data.Models
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public bool Active { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Street> Streets { get; set; } 

    }
}
