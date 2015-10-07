using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationUser = NailsWebApp.Data.Models.Identity.ApplicationUser;

namespace NailsWebApp.Data.Models
{
    public class UserInfo
    {
        [Key]
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Guid? ImageId { get; set; }

        public string SkypeName { get; set; }
        public string VkId { get; set; }
        public string FacebookId { get; set; }
        public string OdkId { get; set; }
        public string TweeterId { get; set; }

        public UserAddress Address { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }
}
