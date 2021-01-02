using Supporter.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Supporter.Entity
{
    [Table("Problemler")]
    public class Problem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //--------------DataContext de tanımlı----------------------------------------
        public int ProblemOlusturanKullaniciId { get; set; }
        [ForeignKey("ProblemOlusturanKullaniciId")]
        public virtual Kullanici.Kullanici ProblemOlusturanKullanici { get; set; }

        public int? ProblemCozenKullaniciId { get; set; }
        [ForeignKey("ProblemCozenKullaniciId")]
        public virtual Kullanici.Kullanici ProblemCozenKullanici { get; set; }
        //----------------------------------------------------------------------------
        public string Resim1 { get; set; }
        public string Resim2 { get; set; }
        public string Resim3 { get; set; }
        public string EkDosya { get; set; }

        //------------------------------------------------------------------------------

        [DisplayName("Problem Tanımı")]
        [StringLength(150, ErrorMessage = "Problem Tanımı 150 Karakteri Geçemez")]
        [Required]
        public string ProblemTanimi { get; set; }

        [DisplayName("Anahtar Kelimeler")]
        [Required]
        public string AnahtarSozcukler { get; set; }

        [DisplayName("Problem Notu")]
        [StringLength(200, ErrorMessage = "Maksimum 200 Karekter Olmalı")]
        public string Not { get; set; }

        public int ProblemTipiId { get; set; }
        public ProblemTipi ProblemTipi { get; set; }
        //public virtual ProblemTipi ProblemTipi { get; internal set; }

        [DisplayName("Çözüm Adım 1")]
        [StringLength(150, ErrorMessage = "Çözüm Adımı 150 Karakteri Geçemez")]
        public string Cozum1 { get; set; }

        [DisplayName("Çözüm Adım 2")]
        [StringLength(150, ErrorMessage = "Çözüm Adımı 150 Karakteri Geçemez")]
        public string Cozum2 { get; set; }
        [DisplayName("Çözüm Adım 3")]
        [StringLength(150, ErrorMessage = "Çözüm Adımı 150 Karakteri Geçemez")]
        public string Cozum3 { get; set; }

        //public List<Cozum> Cozumler { get; set; }

        public int AnaUrunId { get; set; }
        [DisplayName("Ana Ürün")]
        public AnaUrun AnaUrun { get; set; }  // ana ürün tablosundan çekecek


        public int? IlacDepoId { get; set; }
        [DisplayName("Depo Adı")]
        public IlacDepo IlacDepo { get; set; }


        public int VersiyonId { get; set; } //versionlar tablosundan çekecek
        public Entity.Versiyon Versiyon { get; set; }


        public int ModulId { get; set; } //Moduller Tablosundan Çekecek


        [DisplayName("Modül")]
        public Modul Modul { get; set; }


        [DisplayName("Çözüm Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CozumTarihi { get; set; }



        //public int? CalisanId { get; set; }
        //[DisplayName("Oluşturan")]
        //public Calisan Calisan { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Tarih { get; set; }



        public bool Gecerlimi { get; set; }

    }
}