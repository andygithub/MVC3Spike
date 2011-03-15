using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnnotationsMVC3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Example of Data Custom Data Annotations";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
