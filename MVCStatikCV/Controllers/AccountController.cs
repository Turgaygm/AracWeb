using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCStatikCV.Models;

namespace MVCStatikCV.Controllers
{
    public class AccountController : Controller
    {
        AracDBEntities db = new AracDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Anasayfa");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanici p )
        {
            var bilgiler = db.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                
                return RedirectToAction("Index","aracbilgis");
            }
            else
            {
                ViewBag.hata = "Kullanıcı adı veya şifre hatalı";
            }
            return View();
        }
    }
}