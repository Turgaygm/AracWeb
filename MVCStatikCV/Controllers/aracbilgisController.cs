using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCStatikCV.Models;

namespace MVCStatikCV.Controllers
{
    
    public class aracbilgisController : Controller
    {
        private AracDBEntities db = new AracDBEntities();
       
        // GET: aracbilgis
        public ActionResult Index()
        {
            return View(db.aracbilgis.ToList());
            
        }

        // GET: aracbilgis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aracbilgi aracbilgi = db.aracbilgis.Find(id);
            if (aracbilgi == null)
            {
                return HttpNotFound();
            }
            return View(aracbilgi);
        }

        // GET: aracbilgis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: aracbilgis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marka,Seri,Model,Yil,Yakit,Vites,KasaTipi,MotorGucu,MotorHacmi,Cekis,Renk,Plaka,Takas,KM,foto1,foto2,foto3,foto4,foto5,Acıklama")] aracbilgi aracbilgi)
        {
            if (ModelState.IsValid)
            {
                db.aracbilgis.Add(aracbilgi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aracbilgi);
        }

        // GET: aracbilgis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aracbilgi aracbilgi = db.aracbilgis.Find(id);
            if (aracbilgi == null)
            {
                return HttpNotFound();
            }
            return View(aracbilgi);
        }

        // POST: aracbilgis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marka,Seri,Model,Yil,Yakit,Vites,KasaTipi,MotorGucu,MotorHacmi,Cekis,Renk,Plaka,Takas,KM,foto1,foto2,foto3,foto4,foto5,Acıklama")] aracbilgi aracbilgi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracbilgi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aracbilgi);
        }

        // GET: aracbilgis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aracbilgi aracbilgi = db.aracbilgis.Find(id);
            if (aracbilgi == null)
            {
                return HttpNotFound();
            }
            return View(aracbilgi);
        }

        // POST: aracbilgis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aracbilgi aracbilgi = db.aracbilgis.Find(id);
            db.aracbilgis.Remove(aracbilgi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
