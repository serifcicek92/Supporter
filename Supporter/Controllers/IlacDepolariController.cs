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
    public class IlacDepolariController : Controller
    {
        private DataContext db = new DataContext();

        // GET: IlacDepolari
        public ActionResult Index()
        {
            return View(db.IlacDepolari.ToList());
        }

        // GET: IlacDepolari/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IlacDepo ilacDepo = db.IlacDepolari.Find(id);
            if (ilacDepo == null)
            {
                return HttpNotFound();
            }
            return View(ilacDepo);
        }

        // GET: IlacDepolari/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IlacDepolari/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepoAdi")] IlacDepo ilacDepo)
        {
            if (ModelState.IsValid)
            {
                db.IlacDepolari.Add(ilacDepo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ilacDepo);
        }

        // GET: IlacDepolari/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IlacDepo ilacDepo = db.IlacDepolari.Find(id);
            if (ilacDepo == null)
            {
                return HttpNotFound();
            }
            return View(ilacDepo);
        }

        // POST: IlacDepolari/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepoAdi")] IlacDepo ilacDepo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilacDepo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ilacDepo);
        }

        // GET: IlacDepolari/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IlacDepo ilacDepo = db.IlacDepolari.Find(id);
            if (ilacDepo == null)
            {
                return HttpNotFound();
            }
            return View(ilacDepo);
        }

        // POST: IlacDepolari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IlacDepo ilacDepo = db.IlacDepolari.Find(id);
            db.IlacDepolari.Remove(ilacDepo);
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
