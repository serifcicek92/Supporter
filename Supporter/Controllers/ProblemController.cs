using Microsoft.AspNet.Identity;
using Supporter.Entity;
using Supporter.Helper;
using Supporter.Models;
using Supporter.Models.KullaniciDto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;

using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Supporter.Controllers
{
    [KullaniciDogrulama(rol = null)]
    public class ProblemController : Controller
    {
        private DataContext db = new DataContext();
        //var ss = db.Problemler.SqlQuery("sql sorgusu").FirstOrDefault();


        //public ActionResult GetList(){

        //    var problemlist = db.Problemler.Include(p => p.AnaUrun).Include(p => p.Calisan).Include(p => p.Modul).Include(p => p.Versiyon).ToList<Problem>();
        //    //return Json(new { data = problemlist }, JsonRequestBehavior.AllowGet);
        //    return View(problemler.ToList());
        //}

        //-----------------Anı Problem Varlığı Kontrolü---------------------------------------------------------------------------------------------------



        //json olarak problem tanımı varlığı sorgulama scriptim..
        [HttpPost]
        public JsonResult ProblemKontrolu(string kelime)
        {
            
            //string[] degerler = kelime.Split(' ');
            ////var deger = db.Problemler.Where(z => z.ProblemTanimi.Contains(kelime)).FirstOrDefault();
            //var deger = db.Problemler.Where(i => degerler.Contains(i.ProblemTanimi)).FirstOrDefault();

            //var donder = "";
            //if (deger != null)
            //{
            //    donder = deger.ProblemTanimi.ToString();

            //}

            //return Json(donder);

            string[] degerler = kelime.Split(' ');
            //var deger = db.Problemler.Where(z => z.ProblemTanimi.Contains(kelime)).FirstOrDefault();
            var deger = db.Problemler.Select(i => i.ProblemTanimi).ToList();//prblem tanımını seçiyoruz
            for (int i = 0; i < degerler.Length; i++)
            {
                var eger = deger.Where(a => a.Contains(degerler[i].ToString())).ToList();
                
                if (eger.Count !=0)
                {
                    deger = deger.Where(a => a.Contains(degerler[i].ToString())).ToList();
                }
                else
                {
                    string val = degerler[i];
                   var degerss = db.Problemler.Where(b=>b.ProblemTanimi.Contains(val)).Select(b=>b.ProblemTanimi).ToList();
                    deger = degerss;
                }
                /*deger = deger.Where(a => a.Contains(degerler[i].ToString())).ToList();*///hangisi eşleşiyrsa kaydı list dönderiyoruz
            }//burdaki sorun değer e ilk önce bulunan kaydı list olarak dönderiyor fakat döngü tekrarlanınca db den değilde
            //aynı list üzerinden contain ediyor ve bulamayabiliyor...........çözüm ? eğer o anki kelime bulunamıyorsa başa sar?

            var donder = "";
            if (deger.Count > 0)//değer boş değilse
            {
                for (int i = 0; i < deger.Count; i++)
                {
                    donder = deger[i].ToString();
                    if (donder != null || donder != "")
                    {
                        break;
                    }
                }
                

            }

            return Json(donder);

            //----------------------------------------------
            //string deger = kelime.Replace(" ", "");
            //char[] degerharf = deger.ToCharArray();

            //string isd="";

            //int say = 0;//her bir itemin toplan eşleşen harf sayısı

            //int k = 0;//her item benzerlik sayısı
            //var veriler = db.Problemler.Select(s=>s).ToList();
            //int[] benzerliksay = new int[veriler.Count()];
            ////////benzerlik oranı hesapla----------------------------------------------------
            /////
            //int benzerlikOrani = (kelime.Length) - ((kelime.Length)*20/100);      
            
            ////----------------------------------------------------------------------------------

            //foreach (var item in veriler)
            //{
            //    say = 0;
                
            //    char[] metin = item.ProblemTanimi.ToString().ToCharArray();

            //    for (int i = 0; i < metin.Length; i++)
            //    {
            //        for (int j = 0; j < degerharf.Length; j++)
            //        {
            //            if (degerharf[j]==metin[i])
            //            {
            //                say += 1;
            //                break;
            //            }

            //        }
                    
            //    }
            //    if (say >= benzerlikOrani)
            //    {
            //        isd = item.ProblemTanimi.ToString();
            //        break;
            //    }
            //    k += 1;
                
            //}

            //return Json(isd);

            //------------------------------------------------------------------------------------------------------------
            //string durum = "false";
            //var deger = db.Problemler.Where(z => z.ProblemTanimi.Contains(kelime.ToString())).FirstOrDefault();
            //if (deger != null)
            //{
            //    durum = "true";
            //    return Json(deger.ProblemTanimi.ToString());
            //}
            //else
            //{
            //    return Json(durum);
            //}
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        // GET: Problem
        public ActionResult Index()
        {
            //var ss = db.Problemler.SqlQuery("select * from Problemler where AnaUrunId=1").ToList();
            //var deger = ss[0].ProblemOlusturanKullanici.Adi;

            var kullanicilar = db.Kullanicis.Where(k => k.Gecerlimi == true)
                .Select(k => new KullaniciListDto
                {
                    Id = k.Id,
                    AdiSoyadi = k.Adi + " " + k.Soyadi
                });
            //36 karakter sınırı olacak
            ViewBag.AnaUrunId = new SelectList(db.AnaUrunler, "Id", "AnaUrunAdi");
            ViewBag.ModulId = new SelectList(db.Moduller, "Id", "ModulAdi");
            ViewBag.VersiyonId = new SelectList(db.Versiyonlar, "Id", "VersiyonAdi");
            ViewBag.ProblemTipiId = new SelectList(db.ProblemTipleri, "Id", "ProblemTipiAdi");

            ViewBag.IlacDepoId = new SelectList(db.IlacDepolari, "Id", "DepoAdi");
            //ViewBag.CalisanId = new SelectList(db.Calisanlar, "Id", "CalisanAd");

            ViewBag.Users = new SelectList(kullanicilar, "Id", "AdiSoyadi");

            ViewBag.Tarih = new SelectList(db.Problemler, "Tarih", "Tarih");
            FilterModel filterModel = new FilterModel();
            var today = DateTime.Today;
            var lastmonth = new DateTime(today.Year, today.Month - 1, 1);

            filterModel.BasTarih = lastmonth;
            filterModel.BitTarih = DateTime.Now.Date;
            ViewBag.Filter = filterModel;

            return View(new List<Problem>());
        }
        // POST: Problem
        [HttpPost]
        public ActionResult Index(FilterModel filter)
        {
            filter.BasTarih = filter.BasTarih ?? DateTime.Now.AddDays(-1000);
            filter.BitTarih = filter.BitTarih ?? DateTime.Now.AddDays(1000);
            ViewBag.AnaUrunId = new SelectList(db.AnaUrunler, "Id", "AnaUrunAdi", filter.AnaUrunId);
            //ViewBag.CalisanId = new SelectList(db.Calisanlar, "Id", "CalisanAd", filter.CalisanId);
            ViewBag.Users = new SelectList(db.Kullanicis, "Id", "Adi", filter.Users);
           
            ViewBag.ModulId = new SelectList(db.Moduller, "Id", "ModulAdi", filter.ModulId);
            ViewBag.ProblemTipiId = new SelectList(db.Moduller, "Id", "ModulAdi", filter.ModulId);
            ViewBag.VersiyonId = new SelectList(db.Versiyonlar, "Id", "VersiyonAdi", filter.VersiyonId);
            ViewBag.IlacDepoId = new SelectList(db.IlacDepolari, "Id", "DepoAdi", filter.IlacDepoId); 

            var problemler = db.Problemler
                .Include(p => p.AnaUrun)
                .Include(p => p.ProblemOlusturanKullanici)
                .Include(p => p.Modul)
                .Include(p => p.Versiyon)
                .Include(p => p.ProblemTipi)
                .Include(p => p.IlacDepo)
                .Where(i => (filter.ProblemTanimi == null || i.ProblemTanimi.Contains(filter.ProblemTanimi))
                && (filter.Users == null || i.ProblemOlusturanKullaniciId == filter.Users)
                && (filter.ProblemTipiId == null || i.ProblemTipiId == filter.ProblemTipiId)
                && (filter.ModulId == null || i.ModulId == filter.ModulId)
                && (filter.AnaUrunId == null || i.AnaUrunId == filter.AnaUrunId)
                && (filter.VersiyonId == null || i.VersiyonId == filter.VersiyonId)
                && (filter.BasTarih == null || i.Tarih >= filter.BasTarih)
                && (filter.BitTarih == null || i.Tarih <= filter.BitTarih)
                && (filter.IlacDepoId == null || i.IlacDepoId == filter.IlacDepoId)
                //&& (filter.Users == null || i.ProblemCozenId == filter.Users)
                );

            ViewBag.Filter = filter;
            return View(problemler.ToList());
        }

        // GET: Problem/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var problem = from srn in db.Problemler
            //              join mdl in db.Moduller on srn.ModulId equals mdl.Id
            //            where (srn.Id == id)
            //            select new ProblemDto
            //            { Id = srn.Id,
            //                ProblemTanimi = srn.ProblemTanimi,
            //                AnahtarSozcukler = srn.AnahtarSozcukler,
            //                ProblemTipi = srn.ProblemTipi.ProblemTipiAdi,
            //                Cozum1 = srn.Cozum1,
            //                Cozum2 = srn.Cozum2,
            //                Cozum3 = srn.Cozum3,
            //                AnaUrunAdi = srn.AnaUrun.AnaUrunAdi,
            //                ModulAdi = mdl.ModulAdi,
            //                VersiyonId = srn.VersiyonId,
            //                CozumTarihi = srn.CozumTarihi,
            //                Calisan = srn.Calisan.CalisanAd,
            //                Tarih = srn.Tarih,
            //                ProblemOlusturanId = srn.ProblemOlusturanId,
            //                ProblemCozenId = srn.ProblemCozenId
            //            };


            var problem = db.Problemler.Where(i=>i.Id==id)
                          .Select(srn => new ProblemDto
                          {
                              Id = srn.Id,
                              ProblemTanimi = srn.ProblemTanimi,
                              AnahtarSozcukler = srn.AnahtarSozcukler,
                              ProblemTipi = srn.ProblemTipi.ProblemTipiAdi,
                              Not = srn.Not,
                              Cozum1 = srn.Cozum1,
                              Cozum2 = srn.Cozum2,
                              Cozum3 = srn.Cozum3,
                              AnaUrunAdi = srn.AnaUrun.AnaUrunAdi,
                              ModulAdi = srn.Modul.ModulAdi,
                              VersiyonAdi = srn.Versiyon.VersiyonAdi,
                              CozumTarihi = srn.CozumTarihi,
                              CalisanAd = srn.ProblemOlusturanKullanici.Adi,
                              Tarih = srn.Tarih,
                              Resim1=srn.Resim1,
                              Resim2=srn.Resim2,
                              Resim3=srn.Resim3,
                              EkDosya=srn.EkDosya,
                              ProblemOlusturanKullaniciAdiSoyadi = srn.ProblemOlusturanKullanici.Adi + " " + srn.ProblemOlusturanKullanici.Soyadi,
                              ProblemCozenKullaniciAdiSoyadi = srn.ProblemCozenKullanici.Adi + " " + srn.ProblemCozenKullanici.Soyadi
                          });

            //var query =
            //    from problem in db.Problemler
            //    from calisan in db.Calisanlar
            //        .Where(c => c.Id == problem.CalisanId)
            //        .FirstOrDefault()
            //    select new
            //    {
            //        pr = problem,
            //        ca = calisan
            //    }


            //var query =
            //from problem in db.Problemler
            //join calisan in db.Calisanlar on calisan.
            //    .Where(c => c.Id == problem.CalisanId)
            //    .FirstOrDefault()
            //select new
            //{
            //    pr = problem,
            //    ca = calisan
            //}

            //var problem = db.Problemler
            //    .GroupJoin(Problem, problem => problem.CalisanId,)
            //  .GroupJoin(
            //      db.Calisanlar,
            //      prob => prob.CalisanId,
            //      cal => cal.Id,
            //      (cal, prob) => new { c1 = cal, p1 = prob })
            //  .SelectMany(
            //      cal => cal.c1.DefaultIfEmpty(),
            //(cal, prob) => new { Calisans = cal.Calisan, Problem = prob })
            //                  calprob => calprob.Calisans,
            //    (x, y) => new { Category = x.Category, Product = y })
            //.Select(s => new
            //{
            //    CategoryName = s.Category.Name,
            //    ProductName = s.Product.Name
            //})

            //.Where(t => t.Problem.Id == id).FirstOrDefault();

            //var problem = db.Database.SqlQuery<ProblemModel>("sel_problemler @ID", new SqlParameter("ID", id)).FirstOrDefault();
            

            if (problem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Eklendimi = TempData["Eklendimi"];
            TempData["Eklendimi"]=null;
            return View(problem.FirstOrDefault());
        }

        // GET: Problem/Create
        public ActionResult Create()
        {

            ViewBag.AnaUrunId = new SelectList(db.AnaUrunler, "Id", "AnaUrunAdi");
            ViewBag.CalisanId = new SelectList(db.Kullanicis, "Id", "Adi");
            ViewBag.ModulId = new SelectList(db.Moduller, "Id", "ModulAdi");
            ViewBag.ProblemTipiId = new SelectList(db.ProblemTipleri, "Id", "ProblemTipiAdi");
            ViewBag.VersiyonId = new SelectList(db.Versiyonlar, "Id", "VersiyonAdi");
            ViewBag.IlacDepoId = new SelectList(db.IlacDepolari, "Id", "DepoAdi");
            return View();
        }

        // POST: Problem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Problem problem,HttpPostedFileBase Resim1, HttpPostedFileBase Resim2, HttpPostedFileBase Resim3, HttpPostedFileBase EkDosya)
        {
            var path = "";
            if (ModelState.IsValid)
            {
                if (Resim1!=null)
                {
                    if (Resim1.ContentLength>0)
                    {
                        //resim olup olmadığını çek etme
                        if (Path.GetExtension(Resim1.FileName).ToLower()==".jpg"
                            || Path.GetExtension(Resim1.FileName).ToLower() == ".png"
                            || Path.GetExtension(Resim1.FileName).ToLower() == ".gif"
                            || Path.GetExtension(Resim1.FileName).ToLower() == ".jpeg")
                        {
                            path = Path.Combine(Server.MapPath("~/Content/resimler/hatalar"), Resim1.FileName);
                            Resim1.SaveAs(path);
                            problem.Resim1 = Resim1.FileName;
                        }
                    }
                }
                if (Resim2 != null)
                {
                    if (Resim2.ContentLength > 0)
                    {
                        //resim olup olmadığını çek etme
                        if (Path.GetExtension(Resim2.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(Resim2.FileName).ToLower() == ".png"
                            || Path.GetExtension(Resim2.FileName).ToLower() == ".gif"
                            || Path.GetExtension(Resim2.FileName).ToLower() == ".jpeg")
                        {
                            path = Path.Combine(Server.MapPath("~/Content/resimler/hatalar"), Resim2.FileName);
                            Resim2.SaveAs(path);
                            problem.Resim2 = Resim2.FileName;
                        }
                    }
                }
                if (Resim3 != null)
                {
                    if (Resim3.ContentLength > 0)
                    {
                        //resim olup olmadığını çek etme
                        if (Path.GetExtension(Resim3.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(Resim3.FileName).ToLower() == ".png"
                            || Path.GetExtension(Resim3.FileName).ToLower() == ".gif"
                            || Path.GetExtension(Resim3.FileName).ToLower() == ".jpeg")
                        {
                            path = Path.Combine(Server.MapPath("~/Content/resimler/hatalar"), Resim3.FileName);
                            Resim3.SaveAs(path);
                            problem.Resim3 = Resim3.FileName;
                        }
                    }
                }

                if (EkDosya != null)
                {
                    if (EkDosya.ContentLength > 0)
                    {
                        //resim olup olmadığını çek etme
                        if (Path.GetExtension(EkDosya.FileName).ToLower() == ".xls"
                            || Path.GetExtension(EkDosya.FileName).ToLower() == ".xlsx"
                            || Path.GetExtension(EkDosya.FileName).ToLower() == ".doc"
                            || Path.GetExtension(EkDosya.FileName).ToLower() == ".docx"
                            || Path.GetExtension(EkDosya.FileName).ToLower() == ".txt"
                            || Path.GetExtension(EkDosya.FileName).ToLower() == ".pdf")
                        {
                            path = Path.Combine(Server.MapPath("~/Content/resimler/hatalar"), EkDosya.FileName);
                            EkDosya.SaveAs(path);
                            problem.EkDosya = EkDosya.FileName;
                        }
                    }
                }



                DateTime dt = DateTime.Now.Date;

                problem.Tarih = dt;
                problem.ProblemOlusturanKullaniciId = (int)Session["KullaniciId"];//----------------------------------DÜZENLENECEK
                db.Problemler.Add(problem);
                db.SaveChanges();
                TempData["Eklendimi"] = "True";
                return RedirectToAction("Details",new { @id=problem.Id});
            }
            ViewBag.AnaUrunId = new SelectList(db.AnaUrunler, "Id", "Id", problem.AnaUrunId);
            ViewBag.CalisanId = new SelectList(db.Kullanicis, "Id", "Adi", problem.ProblemOlusturanKullaniciId);
            ViewBag.ModulId = new SelectList(db.Moduller, "Id", "ModulAdi", problem.ModulId);
            ViewBag.ProblemTipiId = new SelectList(db.ProblemTipleri, "Id", "ProblemTipiAdi");
            ViewBag.VersiyonId = new SelectList(db.Versiyonlar, "Id", "VersiyonAdi", problem.VersiyonId);
            ViewBag.IlacDepoId = new SelectList(db.IlacDepolari, "Id", "DepoAdi", problem.IlacDepoId);

            
            return View(problem);
        }

        // GET: Problem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problemler.Find(id);



            var czmTrh = problem.CozumTarihi.ToString();
            string str;
            if (czmTrh != "" && czmTrh != null)
            {
                DateTime dt = DateTime.Parse(czmTrh);
                str = dt.ToString("yyyy-MM-dd");
                ViewBag.date = str;
            }



            if (problem == null)
            {
                return HttpNotFound();
            }

            ViewBag.AnaUrunId = new SelectList(db.AnaUrunler, "Id", "AnaUrunAdi", problem.AnaUrunId);
            ViewBag.ProblemOlusturanKullaniciId = new SelectList(db.Kullanicis, "Id", "Adi", problem.ProblemOlusturanKullaniciId);
            ViewBag.ProblemCozenKullaniciId = new SelectList(db.Kullanicis, "Id", "Adi", problem.ProblemCozenKullaniciId);
            ViewBag.ModulId = new SelectList(db.Moduller, "Id", "ModulAdi", problem.ModulId);
            ViewBag.ProblemTipiId = new SelectList(db.ProblemTipleri, "Id", "ProblemTipiAdi",problem.ProblemTipiId);
            ViewBag.VersiyonId = new SelectList(db.Versiyonlar, "Id", "VersiyonAdi", problem.VersiyonId);
            ViewBag.IlacDepoId = new SelectList(db.IlacDepolari, "Id", "DepoAdi",problem.IlacDepoId);

            return View(problem);
        }

        // POST: Problem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Problem problem)
        {
            //problem.ProblemCozenKullaniciId = (int)Session["KullaniciId"];
            DateTime dt = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                problem.CozumTarihi = dt;
                problem.ProblemCozenKullaniciId = (int)Session["KullaniciId"];//----------------------------------DÜZENLENECEK
                db.Entry(problem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnaUrunId = new SelectList(db.AnaUrunler, "Id", "Id", problem.AnaUrunId);
            //ViewBag.CalisanId = new SelectList(db.Kullanicis, "Id", "Adi", problem.ProblemOlusturanKullaniciId);
            ViewBag.ModulId = new SelectList(db.Moduller, "Id", "ModulAdi", problem.ModulId);
            ViewBag.ProblemTipiId = new SelectList(db.ProblemTipleri, "Id", "ProblemTipiAdi");
            ViewBag.VersiyonId = new SelectList(db.Versiyonlar, "Id", "VersiyonAdi", problem.VersiyonId);
            ViewBag.IlacDepoId = new SelectList(db.IlacDepolari, "Id", "DepoAdi", problem.IlacDepoId);
            return View(problem);
        }

        // GET: Problem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problemler.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: Problem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Problem problem = db.Problemler.Find(id);
            db.Problemler.Remove(problem);
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
