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
    public class ProductDetayController : Controller
    {

        Context c = new Context();

        // GET: ProductDetay
        public ActionResult Index(int id)
        {
            var value = c.Products.Where(x => x.ProductID == id).ToList();
            
            return View(value);
        }
    }
}