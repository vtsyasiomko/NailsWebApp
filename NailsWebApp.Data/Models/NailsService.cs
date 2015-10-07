using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationUser = NailsWebApp.Data.Models.Identity.ApplicationUser;

namespace NailsWebApp.Data.Models
{
    public class NailsService
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public ApplicationUser UpdatedBy { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<NailsService> SubService { get; set; }

    }
}
