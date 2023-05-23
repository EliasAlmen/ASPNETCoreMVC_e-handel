using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public int ApplicationUserAddressId { get; set; }
        public ApplicationUserAddress ApplicationUserAddress { get; set; }
        public int ApplicationUserCompanyId { get; set; }
        public ApplicationUserCompany ApplicationUserCompany { get; set; }
    }
}
