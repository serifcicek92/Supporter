using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Supporter.Entity
{
    [Table("Cozumler")]
    public class Cozum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Lütfen en Fazla 150 Karakter Uzunluğunda Bir İsim Giriniz")]
        [DisplayName("Çözüm Yazı")]
        public string CozumYazi { get; set; }
        public List<Problem> Problemler { get; set; }

        public string CozenId { get; set; }
    }
}