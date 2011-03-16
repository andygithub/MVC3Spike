using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsMVC3.Models;

namespace DataAnnotationsMVC3.Controllers
{
    public class ReportController : Controller
    {

        public ActionResult Create()
        {
            return View(new Report());
        }

        [HttpPost]
        public ActionResult Create(Report report)
        {
            if (!ModelState.IsValid)
            {
                return View(report);
            }
            return Content("Report valid!");
        }

    }
}
