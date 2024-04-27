using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using VizeProjesi_Universite.Models.Entity;
using System.Web.Security;

namespace VizeProjesi_Universite.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        VizeProjesi_UniversiteEntities7 db = new VizeProjesi_UniversiteEntities7();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            var adminuserinfo = db.Tbl_Admin.FirstOrDefault(x => x.AdminKullaniciAdi == p.AdminKullaniciAdi && x.AdminParola == p.AdminParola);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminKullaniciAdi, false);
                Session["AdminKullaniciAdi"] = adminuserinfo.AdminKullaniciAdi;
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}