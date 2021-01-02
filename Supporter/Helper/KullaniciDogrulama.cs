using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Supporter.Helper
{
    public class KullaniciDogrulama : AuthorizeAttribute
    {
        public string rol { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext.Session["Rol"]==null && httpContext.Session["Kullanici"] == null)
            {
                httpContext.Response.Redirect("/Kullanicilar/KullaniciGiris");
                return false;
            }
            else if(httpContext.Session["Kullanici"] != null && rol == null)
            {
                return true;
            }
            else if (httpContext.Session["Kullanici"] != null && httpContext.Session["Rol"].ToString() == rol?.ToString())
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Kullanicilar/KullaniciGiris");
                return false;
            }

            //return base.AuthorizeCore(httpContext);
        }

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (this.AuthorizeCore(filterContext.HttpContext))
        //    {
        //        base.OnAuthorization(filterContext);
        //    }
        //    else
        //    {
        //        var _urlReferrer = filterContext.HttpContext.Request.UrlReferrer;
        //        // orada yetkili değilse ya yetkili olduğu sayfaya geri gönderiyoruz
        //        // yada yetkisiz olduğuna dair error page i istemciye gönderiyoruz.
        //        if (_urlReferrer != null)
        //        {
        //            string _redirectUrl = "~" + _urlReferrer.LocalPath;
        //            filterContext.Result = new RedirectResult(_redirectUrl);
        //        }
        //        else
        //        {
        //            // direkt url den talebi göndermiş demektir.
        //            filterContext.Result = new RedirectResult("~/Kullanicilar/KullaniciGiris");
        //        }
        //    }

        //}



        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (SkipAuthorization(filterContext) && (
        //        filterContext.HttpContext.Session["rol"] == null ||
        //        filterContext.HttpContext.Session["rol"].ToString() != rol))
        //    {
        //        filterContext.HttpContext.Response.Clear();
        //        filterContext.HttpContext.Response.StatusCode = 403;
        //        filterContext.HttpContext.Response.End();
        //    }
        //    base.OnAuthorization(filterContext);
        //}

        //private bool SkipAuthorization(AuthorizationContext filterContext) {
        //    return filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any();
        //}

        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    var session = httpContext.Session["Kullanici"].ToString();
        //    if (!String.IsNullOrEmpty(session))
        //    {
        //        return true;
        //    }

        //    return base.AuthorizeCore(httpContext);
        //}
    }
}