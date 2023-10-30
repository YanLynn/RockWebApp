﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RockWebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage = "Display Order must be between 1-100.")]
        public int DisplayOrder { get; set; }
    }
}
