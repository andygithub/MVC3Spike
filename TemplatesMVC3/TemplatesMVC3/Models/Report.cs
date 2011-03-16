using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnnotationsMVC3.Models
{
    public class Report
    {
        public int StartValue { get; set; }
        
        public int EndValue { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }
}