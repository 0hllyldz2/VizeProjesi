using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VizeProjesi_Universite.Models.Entity;

namespace VizeProjesi_Universite.Controllers
{
    public class AdminOgrenciController : Controller
    {
        // GET: AdminOgrenci
        VizeProjesi_UniversiteEntities7 db = new VizeProjesi_UniversiteEntities7();
        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var degerler = db.Tbl_Ogrenci.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
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
        public ActionResult YeniOgrenci(Tbl_Ogrenci p1)
        {
            var ogr = db.TblBolum.Where(m => m.Bolumid == p1.TblBolum.Bolumid).FirstOrDefault();
            p1.TblBolum = ogr;
            db.Tbl_Ogrenci.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.Tbl_Ogrenci.Find(id);
            db.Tbl_Ogrenci.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrc = db.Tbl_Ogrenci.Find(id);
            return View("OgrenciGetir", ogrc);
        }

        public ActionResult Guncelle(Tbl_Ogrenci p1)
        {
            var ogrnc = db.Tbl_Ogrenci.Find(p1.Ogrenciid);
            ogrnc.OgrenciAdSoyad = p1.OgrenciAdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MezunEt(int id)
        {
            try
            {
                var ogrenci = db.Tbl_Ogrenci.Find(id);

                if (ogrenci != null)
                {
                    if (ogrenci.OgrenciNot >= 50)
                    {
                        ogrenci.Durum = true;
                        db.SaveChanges();

                        Tbl_Rapor rapor = new Tbl_Rapor
                        {
                            RaporOgrenciid = ogrenci.Ogrenciid
                        };

                        db.Tbl_Rapor.Add(rapor);
                        db.SaveChanges();

                        TempData["Message"] = "Öğrenci başarıyla mezun edildi.";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Bir hata oluştu: " + ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}