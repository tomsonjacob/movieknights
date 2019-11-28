using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieKnights.Models
{
    public class User
    {
       public int id { get; set; } 

       [Required]
       [MaxLength(100)]
       public string Email { get; set; }

       [Required]
       [MinLength(8)]
       [MaxLength(512)]
       public string Password { get; set; }

       [Required]
       [MaxLength(1)]
       public string Status { get; set; }

    public ICollection<Watch> Watchs { get; set; }

    }   

    
}