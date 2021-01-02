using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Supporter.Entity;
using Supporter.Helper;

namespace Supporter.Controllers
{
    [KullaniciDogrulama(rol = null)]
    public class VersiyonsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Versiyons
        public ActionResult Index()
        {
            return View(db.Versiyonlar.ToList());
        }

        // GET: Versiyons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versiyon versiyon = db.Versiyonlar.Find(id);
            if (versiyon == null)
            {
                return HttpNotFound();
            }
            return View(versiyon);
        }

        // GET: Versiyons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Versiyons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VersiyonAdi")] Versiyon versiyon)
        {
            if (ModelState.IsValid)
            {
                db.Versiyonlar.Add(versiyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(versiyon);
        }

        // GET: Versiyons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versiyon versiyon = db.Versiyonlar.Find(id);
            if (versiyon == null)
            {
                return HttpNotFound();
            }
            return View(versiyon);
        }

        // POST: Versiyons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VersiyonAdi")] Versiyon versiyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(versiyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(versiyon);
        }

        // GET: Versiyons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versiyon versiyon = db.Versiyonlar.Find(id);
            if (versiyon == null)
            {
                return HttpNotFound();
            }
            return View(versiyon);
        }

        // POST: Versiyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Versiyon versiyon = db.Versiyonlar.Find(id);
            db.Versiyonlar.Remove(versiyon);
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
