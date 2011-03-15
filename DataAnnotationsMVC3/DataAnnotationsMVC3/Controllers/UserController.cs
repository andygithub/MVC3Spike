using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsMVC3.Models;

namespace DataAnnotationsMVC3.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return Content("User valid!");
        }

    }


}
