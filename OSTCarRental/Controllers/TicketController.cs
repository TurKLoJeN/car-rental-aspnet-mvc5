using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSTCarRental.Models.Entity;
using PagedList;

namespace OSTCarRental.Controllers
{
    public class TicketController : Controller
    {
        CarRentalEntities db = new CarRentalEntities();
        // GET: Ticket
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var ticket = db.TBLILETISIMGEC.ToList().ToPagedList(sayfa, 6); 
            return View(ticket);
        }
        public ActionResult TicketSil(int id)
        {
            var tck = db.TBLILETISIMGEC.Find(id);
            db.TBLILETISIMGEC.Remove(tck);
            db.SaveChanges();
            TempData["TicketSil"] = "Ticket Başarıyla Silindi.";
            return RedirectToAction("Index");
        }
        public ActionResult TicketGetir(int id)
        {
            var tck = db.TBLILETISIMGEC.Find(id);
            return View("TicketGetir", tck);
        }
    }
}