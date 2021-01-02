using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Supporter.Entity
{
    [Table("IlacDepolari")]
    public class IlacDepo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Lütfen en Fazla 80 Karakter Uzunluğunda Bir İsim Giriniz")]
        [DisplayName("Depo Adı")]
        public string DepoAdi { get; set; }

        public List<Problem> Problemler { get; set; }

    }
}