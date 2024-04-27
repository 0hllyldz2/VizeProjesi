using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VizeProjesi_Universite.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}