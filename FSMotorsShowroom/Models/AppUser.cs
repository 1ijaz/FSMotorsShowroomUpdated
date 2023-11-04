using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class AppUser
    {
        [Key] 
        public int Id { get; set; }
        public string Email { get; set; }
         
        public string Role {  get; set; }
    }
}
