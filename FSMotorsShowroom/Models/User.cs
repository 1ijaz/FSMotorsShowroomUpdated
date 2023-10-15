using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class User : IdentityUser
    {
       
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
    }
}
