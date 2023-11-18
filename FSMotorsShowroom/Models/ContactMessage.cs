using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class ContactMessage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
