using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace SessionlessMVC3.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "This page has session state disabled.";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
