using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supporter.Entity.Kullanici
{
    public class Kullanici
    {
        public int Id { get; set; }

        [DisplayName("Adı")]
        [StringLength(150, ErrorMessage = "Problem Tanımı 150 Karakteri Geçemez")]
        [Required]
        public string Adi { get; set; }

        [DisplayName("SoyAdı")]
        [StringLength(150, ErrorMessage = "Problem Tanımı 150 Karakteri Geçemez")]
        [Required]
        public string Soyadi { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [StringLength(150, ErrorMessage = "Problem Tanımı 150 Karakteri Geçemez")]
        [Required]
        public string KullaniciAdi { get; set; }

        [DisplayName("Parola")]
        [Required]
        public string Parola { get; set; }

        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Parola", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ReParola { get; set; }

        [DisplayName("Mail Adres")]
        public string MailAdres { get; set; }
        public bool Cinsiyet { get; set; }
        public string Telefon { get; set; }

        [DisplayName("Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        public DateTime? OlusturmaTarihi { get; set; }

        [DisplayName("Son Değişiklik Yapan")]
        public DateTime? SonDegisiklikYapan { get; set; }
        public bool Gecerlimi { get; set; }

        //datacontex ile problemlerde bir kullanicinin idsini 2 yerde kullanmak için:
        public virtual ICollection<Problem> OlusturulanProblem { get; set; }
        public virtual ICollection<Problem> CozulenProblem { get; set; }
    }
}