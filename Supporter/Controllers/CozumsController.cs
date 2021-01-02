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
    public class CozumsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Cozums
        public ActionResult Index()
        {
            return View(db.Cozumler.ToList());
        }

        // GET: Cozums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cozum cozum = db.Cozumler.Find(id);
            if (cozum == null)
            {
                return HttpNotFound();
            }
            return View(cozum);
        }

        // GET: Cozums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cozums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CozumYazi")] Cozum cozum)
        {
            if (ModelState.IsValid)
            {
                db.Cozumler.Add(cozum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cozum);
        }

        // GET: Cozums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cozum cozum = db.Cozumler.Find(id);
            if (cozum == null)
            {
                return HttpNotFound();
            }
            return View(cozum);
        }

        // POST: Cozums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CozumYazi")] Cozum cozum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cozum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cozum);
        }

        // GET: Cozums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cozum cozum = db.Cozumler.Find(id);
            if (cozum == null)
            {
                return HttpNotFound();
            }
            return View(cozum);
        }

        // POST: Cozums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cozum cozum = db.Cozumler.Find(id);
            db.Cozumler.Remove(cozum);
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
