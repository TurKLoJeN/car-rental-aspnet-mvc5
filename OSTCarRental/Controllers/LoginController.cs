using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSTCarRental.Models.Entity;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace OSTCarRental.Controllers
{
    public class LoginController : Controller
    {

        CarRentalEntities db = new CarRentalEntities();
        // GET: Login

        public ActionResult GirisYap()
        {
            return View("GirisYap");
        }
        [HttpPost]
        public ActionResult GirisYap(TBLADMIN p)
        {
            string sifre = Sifrele.MD5Olustur(p.PASSWORD);
            var bilgiler = db.TBLADMIN.FirstOrDefault(x => x.USERNAME == p.USERNAME && x.PASSWORD == sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.USERNAME,false);
                return RedirectToAction("Index","Panel");
            }
            else
            {
                TempData["LoginHata"] = "Kullanıcı adı veya Şifreyi Hatalı Girdiniz";
                return View();
            }
            
        }
    }
}
