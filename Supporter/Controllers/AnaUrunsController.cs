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
    public class AnaUrunsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AnaUruns
        public ActionResult Index()
        {
            return View(db.AnaUrunler.ToList());
        }

        // GET: AnaUruns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnaUrun anaUrun = db.AnaUrunler.Find(id);
            if (anaUrun == null)
            {
                return HttpNotFound();
            }
            return View(anaUrun);
        }

        // GET: AnaUruns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnaUruns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AnaUrunAdi")] AnaUrun anaUrun)
        {
            if (ModelState.IsValid)
            {
                db.AnaUrunler.Add(anaUrun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anaUrun);
        }

        // GET: AnaUruns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnaUrun anaUrun = db.AnaUrunler.Find(id);
            if (anaUrun == null)
            {
                return HttpNotFound();
            }
            return View(anaUrun);
        }

        // POST: AnaUruns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AnaUrunAdi")] AnaUrun anaUrun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anaUrun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anaUrun);
        }

        // GET: AnaUruns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnaUrun anaUrun = db.AnaUrunler.Find(id);
            if (anaUrun == null)
            {
                return HttpNotFound();
            }
            return View(anaUrun);
        }

        // POST: AnaUruns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnaUrun anaUrun = db.AnaUrunler.Find(id);
            db.AnaUrunler.Remove(anaUrun);
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
