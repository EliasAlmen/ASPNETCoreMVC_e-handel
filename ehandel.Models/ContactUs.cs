using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehandel.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name = "Email address")]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Company { get; set; }
        [Required]
        [Display(Name = "Comment")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Please keep within comment character limits.")]
        public string Comment { get; set; }
        public DateTime TimeOfContact { get; set; } = DateTime.Now;
    }
}
