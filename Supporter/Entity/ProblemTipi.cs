using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Supporter.Entity
{
    [Table("ProblemTipleri")]
    public class ProblemTipi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:150,ErrorMessage ="En fazla 150 karakter girebilirsiniz")]
        [DisplayName("Problem Tipi")]
        public string ProblemTipiAdi { get; set; }

        public List<Problem> Problemler { get; set; }
    }
}