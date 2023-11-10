using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class Application
    {
        [Key]
        public int id {  get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string higEducation {get; set; }
        public string Age { get; set; }
        public int careerId {  get; set; }
        public virtual Career? Career { get; set; }
    }
}
