using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSTCarRental.Models.Entity;
using PagedList;

namespace OSTCarRental.Controllers
{
    public class KiralaController : Controller
    {
        CarRentalEntities db = new CarRentalEntities();
        // GET: Kirala
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLKIRALA.Where(x => x.DURUM == false).ToList().ToPagedList(sayfa, 6); 
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AracKirala()
        {
            List<SelectListItem> deger1 = (from i in db.TBLARABA.ToList()
                                           where i.DURUM == true
                                           select new SelectListItem
                                           {
                                               Text = i.ARABAISIM,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult AracKirala(TBLKIRALA p)
        {
            var arb = db.TBLARABA.Where(k => k.ID == p.TBLARABA.ID).FirstOrDefault();
            p.TBLARABA = arb;
            db.TBLKIRALA.Add(p);
            db.SaveChanges();
            TempData["AracKirala"] = "Araç başarıyla kiralandı.";
            return RedirectToAction("Index");
        }
        public ActionResult KiraGetir(int id)
        {
            var arb = db.TBLKIRALA.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLARABA.ToList()
                                           where i.DURUM == true
                                           select new SelectListItem
                                           {
                                               Text = i.ARABAISIM,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("KiraGetir", arb);
        }
        public ActionResult KiraGuncelle(TBLKIRALA p)
        {
            var kirala = db.TBLKIRALA.Find(p.ID);
            kirala.ISIM = p.ISIM;
            kirala.MAIL = p.MAIL;
            kirala.TELEFON = p.TELEFON;
            kirala.ALISTARIH = p.ALISTARIH;
            kirala.GETIRTARIH = p.GETIRTARIH;
            var arb = db.TBLARABA.Where(k => k.ID == p.TBLARABA.ID).FirstOrDefault();
            kirala.ARABA = arb.ID;
            db.SaveChanges();
            TempData["KiraGuncelle"] = "Kiralama bilgileri başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
        public ActionResult TeslimAlGetir(int id) 
        {
            var arb = db.TBLKIRALA.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLARABA.ToList()
                                           where i.DURUM == true
                                           select new SelectListItem
                                           {
                                               Text = i.ARABAISIM,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("TeslimAlGetir", arb);

        }
        public ActionResult TeslimAl(TBLKIRALA p)
        {
            var kirala = db.TBLKIRALA.Find(p.ID);
            kirala.GETIRTARIH = p.GETIRTARIH;
            kirala.DURUM = true;
            db.SaveChanges();
            TempData["KiraGuncelle"] = "Kiralama bilgileri başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}