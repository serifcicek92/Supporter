using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Supporter.Entity;
using Supporter.Entity.Kullanici;
using Supporter.Models;
using Supporter.Helper;

namespace Supporter.Controllers
{
    [KullaniciDogrulama(rol = null)]
    public class KullanicilarController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Kullanicilar

        public ActionResult Index()
        {
            var kullanicis = db.Kullanicis.Include(k => k.Rol);
            return View(kullanicis.ToList());
        }

        // GET: Kullanicilar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanicis.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanicilar/Create
        [KullaniciDogrulama(rol = "1")]
        public ActionResult Create()
        {
            ViewBag.RolId = new SelectList(db.Rols, "Id", "RolAdi");
            return View();
        }

        // POST: Kullanicilar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adi,Soyadi,KullaniciAdi,Parola,ReParola,MailAdres,Cinsiyet,Telefon,DogumTarihi,RolId,OlusturmaTarihi,SonDegisiklikYapan,Gecerlimi")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                kullanici.OlusturmaTarihi = DateTime.Now;
                db.Kullanicis.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolId = new SelectList(db.Rols, "Id", "RolAdi", kullanici.RolId);
            return View(kullanici);
        }

        // GET: Kullanicilar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanicis.Find(id);

            if (kullanici.DogumTarihi != null)
            {
                DateTime dt = DateTime.Parse(kullanici.DogumTarihi.ToString());
                ViewBag.DogumTarihi = dt.ToString("yyyy-MM-dd");
            }



            if (kullanici == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolId = new SelectList(db.Rols, "Id", "RolAdi", kullanici.RolId);
            return View(kullanici);
        }

        // POST: Kullanicilar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adi,Soyadi,KullaniciAdi,Parola,ReParola,MailAdres,Cinsiyet,Telefon,DogumTarihi,RolId,OlusturmaTarihi,SonDegisiklikYapan,Gecerlimi")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                kullanici.SonDegisiklikYapan = DateTime.Now;
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(db.Rols, "Id", "RolAdi", kullanici.RolId);
            return View(kullanici);
        }

        // GET: Kullanicilar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanicis.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanicilar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanici kullanici = db.Kullanicis.Find(id);
            db.Kullanicis.Remove(kullanici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Login
        [AllowAnonymous]
        public ActionResult KullaniciGiris()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult KullaniciGiris(KullaniciGiris kg)
        {
            var sorgum = db.Kullanicis.Where(i => i.KullaniciAdi == kg.KullaniciAdi && i.Parola == kg.Sifre).FirstOrDefault();
            if (sorgum != null && sorgum.Gecerlimi == true)
            {


                //ViewBag.girispost = sorgum.KullaniciAdi + " " + sorgum.Parola;
                if (!String.IsNullOrEmpty(sorgum.KullaniciAdi) || !String.IsNullOrEmpty(sorgum.Parola))
                {
                    Session["Kullanici"] = sorgum.KullaniciAdi;
                    Session["KullaniciId"] = sorgum.Id;
                    Session["Rol"] = sorgum.RolId.ToString();
                    ViewBag.girispost = "sessionlar=" + Session["Kullanici"] + " rol idsi=" + Session["Rol"];
                    //Response.Redirect("../Problem");
                    return RedirectToAction("Index", "Problem");

                    //cookie ekleme
                    //HttpCookie cerez = new HttpCookie("hatirla", "deger");
                    //cerez.Expires = DateTime.Now.AddDays(10);
                    //HttpContext.Response.Cookies.Add(cerez);

                    //çerez Boşaltma
                    //cerez.Value = "";
                    //cerez.Expires = DateTime.Now.AddYears(-1);
                    //HttpContext.Response.Cookies.Add(cerez);

                    //ViewBag.girispost = HttpContext.Request.Cookies["hatirla"].Value;//cookie çekme
                }
            }
            else
            {
                ViewBag.GirisKontrol = "Kullanıcı Adı Veya Şifre Geçerli Değil";
            }


            return View();
        }
        public ActionResult Cikis()
        {
            Session.Abandon();
            Response.Redirect("~/Home");
            return View();
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
