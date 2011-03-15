using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions; 

namespace DataAnnotationsMVC3.Models
{
    public class User
    {
        [Required]
        [Email]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EqualTo("Password")]
        public string PasswordConfirm { get; set; }

        [Url]
        public string HomePage { get; set; }

       [Integer]
       [Min(1)]
        public int Age { get; set; }
    }
}