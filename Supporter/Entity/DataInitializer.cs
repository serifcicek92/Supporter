using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Supporter.Entity
{
   // public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
   // {
   //     protected override void Seed(DataContext context)
   //     {

   //         //Kullanici.Rol rol = new Kullanici.Rol();
   //         //rol.RolAdi = "Admin";
   //         //rol.Gecerlimi = true;
   //         //rol.Id = 1;
   //         //context.Rols.Add(rol);
			//var kullaniciRolu = new List<Kullanici.Rol>()
			//{
			//	new Kullanici.Rol(){RolAdi="Admin", Gecerlimi = true},
			//	new Kullanici.Rol(){RolAdi = "User", Gecerlimi = true}
			//};
   //         foreach (var item in kullaniciRolu)
   //         {
   //             context.Rols.Add(item);
   //         }
			//context.SaveChanges();


   //         //Kullanici.Kullanici kullanici = new Kullanici.Kullanici();
   //         //kullanici.Adi = "Admin Adı";
   //         //kullanici.Cinsiyet = true;
   //         //kullanici.Gecerlimi = true;
   //         //kullanici.KullaniciAdi = "admin";
   //         //kullanici.RolId = 1;
   //         //context.Kullanicis.Add(kullanici);

   //         var kullanicilar = new List<Kullanici.Kullanici>()
   //         {
   //             new Kullanici.Kullanici(){Adi = "Admin Adı", Soyadi="Soyadi", Cinsiyet = true, Gecerlimi = true, KullaniciAdi="admin", RolId=1, Parola="123456",ReParola="123456", MailAdres="asdf"},
   //             new Kullanici.Kullanici(){Adi = "user adı", Soyadi="Soyadi", Cinsiyet = true, Gecerlimi = true, KullaniciAdi="user", RolId=2, Parola="123456",ReParola="123456", MailAdres="asdf"}
   //         };
			//foreach(var ekle in kullanicilar)
			//{
			//	context.Kullanicis.Add(ekle);
			//}
   //         context.SaveChanges();


   //         base.Seed(context);
   //     }
    //}
}