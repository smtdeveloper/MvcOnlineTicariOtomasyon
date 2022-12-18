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
    public class DashboardController : Controller
    {
        Context c = new Context();

        // GET: Dashboard
        public ActionResult Index()
        {
            var cariler = c.Concubines.Count().ToString();
            ViewBag.VCariler = cariler;

            var products = c.Products.Count().ToString();
            ViewBag.VProducts = products;

            var categories = c.Categories.Count().ToString();
            ViewBag.VCategories = categories;

            var personeller = c.Employees.Count().ToString();
            ViewBag.VPersoneller = personeller;

            return View();
        }
    }
}