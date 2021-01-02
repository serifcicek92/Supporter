using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supporter.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }


        [Required]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }


        [EmailAddress(ErrorMessage ="E-Posta Adresinizi Düzgün Giriniz")]
        [Required]
        [DisplayName("E-Mail Adresiniz")]
        public string Email { get; set; }


        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }


        [Required]
        [DisplayName("ŞifreTekrar")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string RePassword { get; set; }
    }
}