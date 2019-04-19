using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_Di.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Documentation()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Administrator()
        {
            return View();
        }
    }
}