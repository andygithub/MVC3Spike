using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MsTestMVC3.Models;

namespace MsTestMVC3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ViewResult Details(int Id)
        {            
            Product _item = new Product{Id=Id, Name="Data"};
            return View("Details",_item);
        }

        public ActionResult Category(int Id)
        {
            if (Id < 0) { return RedirectToAction("Index"); }
            Product _item = new Product { Id = Id, Name = "Data" };
            return View("Details", _item);
        }
    }
}
