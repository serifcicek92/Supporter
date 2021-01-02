using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Supporter.Entity;

namespace Supporter.Controllers
{
    [Authorize]
    public class CalisansController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Calisans
        public ActionResult Index()
        {
            return View(db.Calisanlar.ToList());
        }

        // GET: Calisans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

        // GET: Calisans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calisans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CalisanAd,CalisanTel")] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                db.Calisanlar.Add(calisan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calisan);
        }

        // GET: Calisans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

        // POST: Calisans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CalisanAd,CalisanTel")] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calisan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calisan);
        }

        // GET: Calisans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

        // POST: Calisans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calisan calisan = db.Calisanlar.Find(id);
            db.Calisanlar.Remove(calisan);
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
