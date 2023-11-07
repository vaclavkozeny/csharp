using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ukol_init_3.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Přijmení")]
        public string LastName { get; set; }
    }
}
