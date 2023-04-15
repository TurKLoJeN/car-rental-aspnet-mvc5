using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSTCarRental.Models.Entity;

namespace OSTCarRental.Controllers
{
    public class HomeController : Controller
    {
        CarRentalEntities db = new CarRentalEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hakkimizda()
        {
            var hakkimizda = db.TBLHAKKIMIZDA.ToList();
            return View(hakkimizda);
        }
        public ActionResult Iletisim()
        {
            var bilgi = db.TBLILETISIMBILGI.ToList();
            return View(bilgi);
        }
        public ActionResult Araclar()
        {
            var araclar = db.TBLARABA.ToList();
            return View(araclar);
        }
        [HttpGet]
        public ActionResult IletisimKur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IletisimKur(TBLILETISIMGEC p)
        {
            db.TBLILETISIMGEC.Add(p);
            db.SaveChanges();
            TempData["Message"] = "Mesajınız bize ulaştı. En yakın zamanda size geri dönülecektir.";
            return View();
        }
        public ActionResult AracGetir(int id)
        {
            var arb = db.TBLARABA.Find(id);
            return View("AracGetir",arb);
        }
    }
}