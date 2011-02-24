using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheMVC3.Controllers
{
    

    public class HomeController : Controller
    {
        public const string _DefaultCacheProfile = "CacheDefaultTenSeconds";
        
        //cacheprofile is defined in the web.config
        [OutputCache(CacheProfile = _DefaultCacheProfile)]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        [OutputCache(Duration = 10, VaryByParam = "none", NoStore = true)]
        public ActionResult About()
        {
            return View();
        }
    }
}
