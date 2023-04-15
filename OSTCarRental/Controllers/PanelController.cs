using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OSTCarRental.Models.Entity;
using OSTCarRental.Models.Siniflarim;

namespace OSTCarRental.Controllers
{
    public class PanelController : Controller
    {
        CarRentalEntities db = new CarRentalEntities();
        // GET: Panel
        [Authorize]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            var deger1 = db.TBLARABA.Count();
            ViewBag.dgr1 = deger1;
            var deger2 = db.TBLKATEGORI.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.TBLKIRALA.Count();
            ViewBag.dgr3 = deger3;
            var deger4 = db.TBLILETISIMGEC.Count();
            ViewBag.dgr4 = deger4;
            cs.Araba = db.TBLARABA.Take(5).ToList();
            cs.Kategori = db.TBLKATEGORI.Take(5).ToList();
            cs.Kirala = db.TBLKIRALA.Take(5).ToList();
            return View(cs);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }
    }
}