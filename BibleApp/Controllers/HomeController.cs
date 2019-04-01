using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A Bible Verse app created by Jackie Adair for CST-247.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "jak@trilixium.com";

            return View();
        }
    }
}