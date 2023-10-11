using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS_Motors.Models
{
    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; } //primary
        public string? User_Type { get; set; } //admin, investor, buyer
    }
}
