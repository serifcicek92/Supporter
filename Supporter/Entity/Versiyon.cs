using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Supporter.Entity
{
    [Table("Versiyonlar")]
    public class Versiyon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Verisyon Adı")]
        [Required]
        public string VersiyonAdi { get; set; }

        public List<Problem> Problemler { get; set; }


    }
}