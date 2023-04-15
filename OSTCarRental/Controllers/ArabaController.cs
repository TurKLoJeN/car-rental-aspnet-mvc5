using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSTCarRental.Models.Entity;
using PagedList;

namespace OSTCarRental.Controllers
{
    public class ArabaController : Controller
    {

        CarRentalEntities db = new CarRentalEntities();
        // GET: Araba
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var arabalar = db.TBLARABA.ToList().ToPagedList(sayfa, 6);
            return View(arabalar);
        }
        [HttpGet]
        public ActionResult ArabaEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult ArabaEkle(TBLARABA p, HttpPostedFileBase RESIM)
        {
            if (Request.Files.Count > 0)
            {
                var fileName = Path.GetFileName(RESIM.FileName);
                var fileExtension = Path.GetExtension(RESIM.FileName);
                var filePath = Path.Combine(Server.MapPath("~/Image"), fileName + fileExtension);
                RESIM.SaveAs(filePath);
                p.RESIM = "/Image/" + fileName + fileExtension;
            }
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            p.TBLKATEGORI = ktg;
            db.TBLARABA.Add(p);
            db.SaveChanges();
            TempData["AracEkle"] = "Filoya Yeni Araç Eklendi.";
            return RedirectToAction("Index");
        }
        public ActionResult ArabaSil(int id)
        {
            var araba = db.TBLARABA.Find(id);
            db.TBLARABA.Remove(araba);
            db.SaveChanges();
            TempData["AracSil"] = "Araba Filodan Silindi.";
            return RedirectToAction("Index");
        }
        public ActionResult ArabaGetir(int id)
        {
            var arb = db.TBLARABA.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("ArabaGetir", arb);
        }
        public ActionResult ArabaGuncelle(TBLARABA p, HttpPostedFileBase RESIM)
        {
            var araba = db.TBLARABA.Find(p.ID);
            if (araba == null)
            {
                return HttpNotFound();
            }

            // Araba bilgilerini güncelle
            araba.ARABAISIM = p.ARABAISIM;
            araba.PLAKA = p.PLAKA;
            araba.DURUM = true;
            araba.ARABADETAY = p.ARABADETAY;
            araba.ARABAFIYAT = p.ARABAFIYAT;
            var ktg = db.TBLKATEGORI.Find(p.TBLKATEGORI.ID);
            if (ktg == null)
            {
                return HttpNotFound();
            }
            araba.KATEGORI = ktg.ID;

            // Resim dosyası varsa kaydet ve yolu güncelle
            if (RESIM != null && RESIM.ContentLength > 0)
            {
                var fileName = Path.GetFileName(RESIM.FileName);
                var fileExtension = Path.GetExtension(RESIM.FileName);
                var filePath = Path.Combine(Server.MapPath("~/Image"), fileName + fileExtension);
                RESIM.SaveAs(filePath);
                araba.RESIM = "/Image/" + fileName + fileExtension;
            }
            
            try
            {
                // Veritabanını güncelle
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Hata oluştuysa hatayı göster
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

            TempData["AracGuncelle"] = "Arabanın bilgileri başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}