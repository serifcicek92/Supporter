using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supporter.Models
{
    public class KullaniciGiris
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string Sifre { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool BeniHatırla { get; set; }
    }
}