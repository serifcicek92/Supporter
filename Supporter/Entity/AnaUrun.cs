using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Supporter.Entity
{
    [Table("AnaUrunler")]
    public class AnaUrun
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Ana Ürün")]
        [StringLength(150, ErrorMessage = "Ana Ürün Adı 150 Karakteri Geçemez")]
        public string AnaUrunAdi { get; set; }

        public List<Problem> Problemler { get; set; }
    }
}