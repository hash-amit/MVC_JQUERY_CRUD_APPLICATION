using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_JQUERY_INSERT_DISPLAY_PRACTICE_01.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Teachers
        public ActionResult TeachersForm()
        {
            return View();
        }
    }
}