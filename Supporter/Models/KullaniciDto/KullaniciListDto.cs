using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supporter.Models.KullaniciDto
{
    public class KullaniciListDto
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string AdiSoyadi { get; set; }
        public string Telefon { get; set; }
        public string MailAdress { get; set; }

    }
}