using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DependencyMVC3.Services;

namespace DependencyMVC3.Controllers
{
    public class HomeController : Controller
    {
        private IMessageService MessageService { get; set; }

        public HomeController(IMessageService service)
        {
            MessageService = service;
        }

        public ActionResult Index()
        {
            ViewBag.Message = MessageService.GetMessage();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
