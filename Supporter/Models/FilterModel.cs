using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supporter.Models
{
    public class FilterModel
    {
        public string ProblemTanimi { get; set; }
        public int? CalisanId { get; set; }

        public int? Users { get; set; }
        public int? AnaUrunId { get; set; }
        public int? ModulId { get; set; }
        public int? VersiyonId { get; set; }
        public int? ProblemTipiId { get; set; }
        public int? IlacDepoId { get; set; }
        public DateTime? BasTarih { get; set; }
        public DateTime? BitTarih { get; set; }


    }
}