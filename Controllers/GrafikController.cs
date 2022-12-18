using MvcOnlineTicariOtomasyon.Models;
using MvcOnlineTicariOtomasyon.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }

         public List<PoductStokModel> ProductList()
        {
            List<PoductStokModel> model = new List<PoductStokModel>();
            using (var c = new Context())
            {
                model = c.Products.Select(x => new PoductStokModel
                {
                    name = x.ProductName,
                    stok = x.Stok
                }).ToList();
            }
            return model;
        }

    }
}