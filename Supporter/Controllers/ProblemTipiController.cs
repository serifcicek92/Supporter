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
    public class ProblemTipiController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ProblemTipi
        public ActionResult Index()
        {
            return View(db.ProblemTipleri.ToList());
        }

        // GET: ProblemTipi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemTipi problemTipi = db.ProblemTipleri.Find(id);
            if (problemTipi == null)
            {
                return HttpNotFound();
            }
            return View(problemTipi);
        }

        // GET: ProblemTipi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProblemTipi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProblemTipiAdi")] ProblemTipi problemTipi)
        {
            if (ModelState.IsValid)
            {
                db.ProblemTipleri.Add(problemTipi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problemTipi);
        }

        // GET: ProblemTipi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemTipi problemTipi = db.ProblemTipleri.Find(id);
            if (problemTipi == null)
            {
                return HttpNotFound();
            }
            return View(problemTipi);
        }

        // POST: ProblemTipi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProblemTipiAdi")] ProblemTipi problemTipi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problemTipi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(problemTipi);
        }

        // GET: ProblemTipi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemTipi problemTipi = db.ProblemTipleri.Find(id);
            if (problemTipi == null)
            {
                return HttpNotFound();
            }
            return View(problemTipi);
        }

        // POST: ProblemTipi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProblemTipi problemTipi = db.ProblemTipleri.Find(id);
            db.ProblemTipleri.Remove(problemTipi);
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
