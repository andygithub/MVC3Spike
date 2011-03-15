using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using DataAnnotationsMVC3.Utilities;
using System.Web.Mvc;

namespace DataAnnotationsMVC3.Models
{
    public class Report
    {
        [Required]
        [Integer]
        public int StartValue { get; set; }
        
        [Required]
        [Integer]
        [GreaterThan("StartValue")]
        public int EndValue { get; set; }
        
        [Required]
        [Date]
        [Remote("IsDateAvailable","Validation")]
        public DateTime StartDate { get; set; }
        
        [Required]
        [Date]        
        public DateTime EndDate { get; set; }
    }
}