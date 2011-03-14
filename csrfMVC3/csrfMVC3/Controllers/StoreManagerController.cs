using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using csrfMVC3.Models;

namespace csrfMVC3.Controllers
{
    
    public class StoreManagerController : Controller
    {

        public const string SaltValue = "Unknown";

        public ActionResult Index()
        {
            return View();
        }
   

        public ActionResult Edit(int id)
        {
            return View(new Album {GenreId=1,Price=22, Title="Undefined" });

        }

        [ValidateAntiForgeryToken(Salt=SaltValue)]
        [HttpPost]        
        public ActionResult Edit(Album item)
        {
            return View(item);

        }

        [Framework.AjaxAntiForgery.AjaxValidateAntiForgeryToken(Salt = SaltValue)]
        public String ExamineTextBox(string textBox1)
        {
            if (textBox1 != "Initial Data")
            {
                return "This text was posted to the server. " + System.DateTime.Now.ToString();
            }
            return String.Empty;
        }

    }
}
