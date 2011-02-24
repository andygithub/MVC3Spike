using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JSONMVC3.Models;

namespace JSONMVC3.Controllers
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

        [HttpPost]
        public ActionResult Search(ImageSearchInput input)
        {
            
            return new JsonResult() { Data = new List<ImageInfo> { new ImageInfo{FileName="test.png", ImageURL="google.com/images"} } };
        }

    }
}
