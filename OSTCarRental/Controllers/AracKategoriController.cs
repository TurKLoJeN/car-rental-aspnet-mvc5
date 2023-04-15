using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSTCarRental.Models.Entity;
using PagedList;

namespace OSTCarRental.Controllers
{
    public class AracKategoriController : Controller
    {
        CarRentalEntities db = new CarRentalEntities();
        // GET: AracKategori
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var kategori = db.TBLKATEGORI.ToList().ToPagedList(sayfa, 6);
            return View(kategori);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            TempData["KategoriEkle"] = "Yeni Kategori Başarıyla Eklendi.";
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(ktg);
            db.SaveChanges();
            TempData["KategoriSil"] = "Kategori Başarıyla Silindi.";
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.KATEGORIAD = p.KATEGORIAD;
            db.SaveChanges();
            TempData["KategoriGuncelle"] = "Kategori Başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }
    }
}