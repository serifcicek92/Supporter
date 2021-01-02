using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supporter
{
    public static class UserHelper
    {
        public static int Rol {
            get {

                return Convert.ToInt32(HttpContext.Current.Session["Rol"]);
            }
            set
            {
                HttpContext.Current.Session["Rol"] = value;
            }
        }
    }
}