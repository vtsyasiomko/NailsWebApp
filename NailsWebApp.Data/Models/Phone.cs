using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsApp.Data.Models
{
    public class Phone
    {
        public Guid Id { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }
        public bool Active { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
