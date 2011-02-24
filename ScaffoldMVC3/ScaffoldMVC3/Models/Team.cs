using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScaffoldMVC3.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime Founded { get; set; }
    }

}