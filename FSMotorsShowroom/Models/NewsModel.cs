using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMotorsShowroom.Models
{
    public class NewsModel
    {
        [Key]
        public int NewsId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string? NewsTitle { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? NewsImage { get; set; }
        [NotMapped]
        [DisplayName("News Image")]
        public IFormFile NewsImageFile { get; set; }

    }
}
