using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMaleabAlKorbV2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registers()
        {
            return View();
        }

        public ActionResult Reservations()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}