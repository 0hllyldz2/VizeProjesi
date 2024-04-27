﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VizeProjesi_Universite.Models.Entity;

namespace VizeProjesi_Universite.Controllers
{
    public class AdminRaporController : Controller
    {
        // GET: AdminRapor
        VizeProjesi_UniversiteEntities7 db = new VizeProjesi_UniversiteEntities7();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Rapor.ToList();
            return View(degerler);
        }
    }
}