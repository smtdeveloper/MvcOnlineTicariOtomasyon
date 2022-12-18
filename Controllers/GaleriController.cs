using MvcOnlineTicariOtomasyon.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    [Authorize]
    public class GaleriController : Controller
    {
        Context c = new Context();
       

        // GET: Galeri
        public ActionResult Index()
        {

            var values = c.Products.Where(x=> x.Status == true).ToList();
            return View(values);

        }
    }
}