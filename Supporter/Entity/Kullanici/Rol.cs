using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supporter.Entity.Kullanici
{
    public class Rol
    {
        public int Id { get; set; }
        public string RolAdi { get; set; }
        public bool Gecerlimi { get; set; }
        public List<Kullanici> Kullanici { get; set; }
    }
}