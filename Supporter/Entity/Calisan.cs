using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Supporter.Entity
{
    [Table("Calisanlar")]
    public class Calisan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50,ErrorMessage ="Lütfen en Fazla 50 Karakter Uzunluğunda Bir İsim Giriniz")]
        [DisplayName("Çalışan Ad")]
        public string CalisanAd { get; set; }
        [DisplayName("Çalışan Telefon")]
        public string CalisanTel { get; set; }
        public List<Problem> Problemler { get; set; }

        //diğer bilgiler eklenebilir
    }
}