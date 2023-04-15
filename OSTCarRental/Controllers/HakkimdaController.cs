using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSTCarRental.Models.Entity;

namespace OSTCarRental.Controllers
{
    public class HakkimdaController : Controller
    {
        CarRentalEntities db = new CarRentalEntities();
        // GET: Hakkimda
        [Authorize]
        public ActionResult Index(int id=1)
        {
            var ktg = db.TBLHAKKIMIZDA.Find(id);
            return View("Index", ktg);
        }
        public ActionResult HakkimdaGuncelle(TBLHAKKIMIZDA p) 
        {
            var hakkimda = db.TBLHAKKIMIZDA.Find(p.ID);
            hakkimda.ACIKLAMA = p.ACIKLAMA;
            db.SaveChanges();
            TempData["HakkimdaGuncelle"] = "Hakkımızda Yazısı Başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }
    }
}