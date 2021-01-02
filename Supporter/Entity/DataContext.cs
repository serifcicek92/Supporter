using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Supporter.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
            //Database.SetInitializer(new DataInitializer());
            //Database.SetInitializer(new DataInitializer()); test verilerini çalıştırabiliriz global.asax.cs de tanımlayabiliriz
        }
        public DbSet<Versiyon> Versiyonlar { get; set; }
        public DbSet<Problem> Problemler { get; set; }
        public DbSet<Modul> Moduller  { get; set; }
        public DbSet<Cozum> Cozumler { get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<AnaUrun> AnaUrunler { get; set; }
        public DbSet<ProblemTipi> ProblemTipleri { get; set; }
        public DbSet<IlacDepo> IlacDepolari { get; set; }
        public DbSet<Supporter.Entity.Kullanici.Kullanici> Kullanicis { get; set; }

        public DbSet<Supporter.Entity.Kullanici.Rol> Rols { get; set; }
        public object Kullanicilar { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Problem>()
            //    .HasRequired(m => m.ProblemCozenKullanici)
            //    .WithMany(t => t.CozulenProblem)
            //    .HasForeignKey(m => m.ProblemCozenKullaniciId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Problem>()
            //    .HasOptional(m => m.ProblemOlusturanKullanici)
            //    .WithMany(t => t.OlusturulanProblem)
            //    .HasForeignKey(m => m.ProblemOlusturanKullaniciId)
            //    .WillCascadeOnDelete(false);
                
            //base.OnModelCreating(modelBuilder);
        }

        //public System.Data.Entity.DbSet<Supporter.Entity.Depo> Depoes { get; set; }
        //public DbSet<Kullanici> Kullanicilar { get; set; }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Problem>()
        //                .HasRequired(m => m.ProblemCozenKullanici)
        //                .WithMany(t => t.CozulenProblem)
        //                .HasForeignKey(m => m.ProblemCozenKullaniciId)
        //                .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Problem>()
        //                .HasRequired(m => m.ProblemOlusturanKullanici)
        //                .WithMany(t => t.OlusturulanProblem)
        //                .HasForeignKey(m => m.ProblemOlusturanKullaniciId)
        //                .WillCascadeOnDelete(false);
        //}


    }
}