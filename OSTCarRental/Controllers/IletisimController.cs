using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSTCarRental.Models.Entity;
namespace OSTCarRental.Controllers
{
    public class IletisimController : Controller
    {
        CarRentalEntities db = new CarRentalEntities();
        // GET: Iletisim
        [Authorize]
        public ActionResult Index(int id=1)
        {
            var ilt = db.TBLILETISIMBILGI.Find(id);
            return View("Index", ilt);
        }
        public ActionResult IletisimGuncelle(TBLILETISIMBILGI p) 
        {
            var iletisim = db.TBLILETISIMBILGI.Find(p.ID);
            iletisim.PHONE = p.PHONE;
            iletisim.EMAIL = p.EMAIL;
            iletisim.GOOGLEMAP = p.GOOGLEMAP;
            db.SaveChanges();
            TempData["IletisimGuncelle"] = "İletişim Bilgileri Başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }
    }
}