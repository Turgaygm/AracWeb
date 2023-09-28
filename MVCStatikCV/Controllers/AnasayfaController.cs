using MVCStatikCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStatikCV.Controllers
{
    public class AnasayfaController : Controller
    {
        AracDBEntities db = new AracDBEntities();

        // GET: Anasayfa
        
        public ActionResult index()
        {
            return View(db.aracbilgis.ToList());
        }
        
    }
}