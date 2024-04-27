using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VizeProjesi_Universite.Models.Entity;

namespace VizeProjesi_Universite.Controllers
{
    public class AdminIPersonelController : Controller
    {
        // GET: AdminIPersonel
        VizeProjesi_UniversiteEntities7 db = new VizeProjesi_UniversiteEntities7();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = db.Tbl_IPersonel.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniIPersonel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniIPersonel(Tbl_IPersonel p1)
        {
            db.Tbl_IPersonel.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var personel = db.Tbl_IPersonel.Find(id);
            db.Tbl_IPersonel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IPersonelGetir(int id)
        {
            var prsl = db.Tbl_IPersonel.Find(id);
            return View("IPersonelGetir", prsl);
        }

        public ActionResult Guncelle(Tbl_IPersonel p1)
        {
            var prsln = db.Tbl_IPersonel.Find(p1.IPersonelid);
            prsln.IPersonelAdSoyad = p1.IPersonelAdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PasifEt(int id)
        {
            var ipersonel = db.Tbl_IPersonel.Find(id);

            ipersonel.IPersonelAyrilmaT = DateTime.Now;
            ipersonel.Durum = true;
            db.SaveChanges();

            var rapor = new Tbl_Rapor
            {
                RaporIPersonelid = ipersonel.IPersonelid
            };

            db.Tbl_Rapor.Add(rapor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}