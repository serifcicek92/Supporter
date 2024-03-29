﻿using System;
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
    public class ModulsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Moduls
        public ActionResult Index()
        {
            return View(db.Moduller.ToList());
        }

        // GET: Moduls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduller.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // GET: Moduls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moduls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ModulAdi")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Moduller.Add(modul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modul);
        }

        // GET: Moduls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduller.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // POST: Moduls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ModulAdi")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modul);
        }

        // GET: Moduls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduller.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // POST: Moduls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modul modul = db.Moduller.Find(id);
            db.Moduller.Remove(modul);
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
