using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsWebApp.Data.Models
{
    public class UserAddress
    {
        [Key]
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string House { get; set; }
        public string Appartment { get; set; }
        public int PostCode { get; set; }

    }
}
