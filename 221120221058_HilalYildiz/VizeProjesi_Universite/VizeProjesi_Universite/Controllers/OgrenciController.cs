using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VizeProjesi_Universite.Models.Entity;

namespace VizeProjesi_Universite.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        VizeProjesi_UniversiteEntities7 db = new VizeProjesi_UniversiteEntities7();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Ogrenci.ToList();
            return View(degerler);
        }
    }
}