using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }
        public bool? IsActive { get; set; }

    }
}
