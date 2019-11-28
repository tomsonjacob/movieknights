using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieKnights.Models
{
    public class Watch
    {
        public int id { get; set; } 
        [Required]
        public DateTime DateAdded { get; set; } 
        [Required]
        [MaxLength(1)]
        public string Status { get; set; } 

        public int UserID { get; set; } 
        public User User { get; set; } 
        [Required]
        public string MovieID { get; set; } 
    }
}