using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VizeProjesi_Universite.Models.Entity;

namespace VizeProjesi_Universite.Controllers
{
    public class AdminAPersonelController : Controller
    {
        // GET: AdminAPersonel
        VizeProjesi_UniversiteEntities7 db = new VizeProjesi_UniversiteEntities7();             
        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var degerler = db.Tbl_APersonel.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniAPersonel()
        {
            List<SelectListItem> degerler = (from i in db.TblBolum.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.BolumAdi,
                                                 Value = i.Bolumid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniAPersonel(Tbl_APersonel p1)
        {
            var prs = db.TblBolum.Where(m => m.Bolumid == p1.TblBolum.Bolumid).FirstOrDefault();
            p1.TblBolum = prs;
            db.Tbl_APersonel.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var personel = db.Tbl_APersonel.Find(id);
            db.Tbl_APersonel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult APersonelGetir(int id)
        {
            var prsl = db.Tbl_APersonel.Find(id);
            return View("APersonelGetir", prsl);
        }

        public ActionResult Guncelle(Tbl_APersonel p1)
        {
            var prsln = db.Tbl_APersonel.Find(p1.APersonelid);
            prsln.APersonelAdSoyad = p1.APersonelAdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PasifEt(int id)
        {
            var apersonel = db.Tbl_APersonel.Find(id);

            apersonel.APersonelAyrilmaT = DateTime.Now;
            apersonel.Durum = true;
            db.SaveChanges();

            var rapor = new Tbl_Rapor
            {
                RaporAPersonelid = apersonel.APersonelid
            };

            db.Tbl_Rapor.Add(rapor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}