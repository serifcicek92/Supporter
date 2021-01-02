using Supporter.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Supporter.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            //_context.Problemler.Where(i=>i.Id == id).FirstOurDefault()
            //action resulta bir id gönderip sorgulama yapılabilir tek veri döndermek için kullanılır

            return View(_context.Problemler.ToList());
        }
    }
}