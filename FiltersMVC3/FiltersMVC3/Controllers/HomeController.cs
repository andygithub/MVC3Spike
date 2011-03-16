using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiltersMVC3.Utilities;
using System.Threading;

namespace FiltersMVC3.Controllers
{    
    public class HomeController : Controller
    {
        [RequestTimingFilter]
        public ActionResult Index()
        {
            ViewBag.Message = "Filters";
            Thread.Sleep(100);
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
