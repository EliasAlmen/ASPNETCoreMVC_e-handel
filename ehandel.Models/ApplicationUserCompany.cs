using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.Models
{
    public class ApplicationUserCompany
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();
    }
}
