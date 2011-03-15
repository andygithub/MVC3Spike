using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnnotationsMVC3.Controllers
{
    public class ValidationController : Controller
    {

        public JsonResult IsDateAvailable(DateTime StartDate)
        {
            if (StartDate >= System.DateTime.Today)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json("This date is not available", JsonRequestBehavior.AllowGet);
        }

    }
}
