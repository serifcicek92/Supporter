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
    public class ProblemDto
    {
        public int Id { get; set; }
        public string ProblemTanimi { get; set; }
        public string AnahtarSozcukler { get; set; }
        public string ProblemTipi { get; set; }
        public string Not { get; set; }
        public string Resim1 { get; set; }
        public string Resim2 { get; set; }
        public string Resim3 { get; set; }
        public string EkDosya { get; set; }
        public string Cozum1 { get; set; }
        public string Cozum2 { get; set; }
        public string Cozum3 { get; set; }
        public string AnaUrun { get; set; }
        public string Modul { get; set; }
        public string Versiyon { get; set; } //versionlar tablosundan çekecek
        public DateTime? CozumTarihi { get; set; }
        public string CalisanAd { get; set; }
        public DateTime? Tarih { get; set; }

        public string ProblemOlusturan { get; set; }
        public string ProblemCozen { get; set; }
        public string AnaUrunAdi { get; internal set; }
        public string ModulAdi { get; internal set; }
        public int VersiyonId { get; internal set; }
        public string ProblemCozenKullaniciAdiSoyadi { get; internal set; }
        public string VersiyonAdi { get; internal set; }
        public string ProblemOlusturanAdiSoyadi { get; internal set; }
        public string ProblemOlusturanKullaniciAdiSoyadi { get; internal set; }
    }
}