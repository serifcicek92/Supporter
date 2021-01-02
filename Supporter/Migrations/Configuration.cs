namespace Supporter.Migrations
{
    using Supporter.Entity;
    using Supporter.Entity.Kullanici;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Supporter.Entity.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Supporter.Entity.DataContext context)
        {
            var anaUrunler = new List<AnaUrun>
            {
                new AnaUrun(){AnaUrunAdi="Boyut"},
                new AnaUrun(){AnaUrunAdi="Fox"}
            };
            foreach (var item in anaUrunler)
            {
                context.AnaUrunler.Add(item);
            }
            context.SaveChanges();
            //-----------------------------------------

            var moduller = new List<Modul>()
            {
                new Modul(){ ModulAdi  = "Stok"},
                new Modul(){ ModulAdi  = "Çek"},
                new Modul(){ ModulAdi  = "Cari"}
            };

            foreach (var item in moduller)
            {
                context.Moduller.Add(item);
            }
            context.SaveChanges();
            //---------------------------------

            var problemTipi = new List<ProblemTipi>()
            {
                new ProblemTipi(){ ProblemTipiAdi  = "Data Baðýmlý"},
                new ProblemTipi(){ ProblemTipiAdi  = "Bozuk Data"},
                new ProblemTipi(){ ProblemTipiAdi  = "Yazýlým Bug"},
                new ProblemTipi(){ ProblemTipiAdi  = "Hata Deðil"},
                new ProblemTipi(){ ProblemTipiAdi  = "Kullanýcý Yönlendirme"}
            };
            foreach (var item in problemTipi)
            {
                context.ProblemTipleri.Add(item);
            }
            context.SaveChanges();

            //-----------------------------------------------------------------

            var versiyon = new List<Versiyon>()
            {
                new Versiyon(){ VersiyonAdi ="Selçuk"},
                new Versiyon(){ VersiyonAdi ="Nevzat"},
                new Versiyon(){ VersiyonAdi ="Tüm"}
            };
            foreach (var item in versiyon)
            {
                context.Versiyonlar.Add(item);
            }
            context.SaveChanges();
            //-----------------------------------------------------
            Rol rol = new Rol();
            //rol.RolAdi = "Admin";
            //rol.Gecerlimi = true;
            //rol.Id = 1;
            //context.Rols.Add(rol);
            var kullaniciRolu = new List<Rol>()
            {
                new Rol(){RolAdi="Admin", Gecerlimi = true},
                new Rol(){RolAdi = "User", Gecerlimi = true}
            };
            foreach (var item in kullaniciRolu)
            {
                context.Rols.Add(item);
            }
            context.SaveChanges();


            //Kullanici.Kullanici kullanici = new Kullanici.Kullanici();
            //kullanici.Adi = "Admin Adý";
            //kullanici.Cinsiyet = true;
            //kullanici.Gecerlimi = true;
            //kullanici.KullaniciAdi = "admin";
            //kullanici.RolId = 1;
            //context.Kullanicis.Add(kullanici);

            var kullanicilar = new List<Kullanici>()
                     {
                         new Kullanici(){Adi = "Admin Adý", Soyadi="Soyadi", Cinsiyet = true, Gecerlimi = true, KullaniciAdi="admin", RolId=1, Parola="123456",ReParola="123456", MailAdres="asdf"},
                         new Kullanici(){Adi = "user adý", Soyadi="Soyadi", Cinsiyet = true, Gecerlimi = true, KullaniciAdi="user", RolId=2, Parola="123456",ReParola="123456", MailAdres="asdf"}
                     };
            foreach (var ekle in kullanicilar)
            {
                context.Kullanicis.Add(ekle);
            }




            context.SaveChanges();
        }
    }
}
