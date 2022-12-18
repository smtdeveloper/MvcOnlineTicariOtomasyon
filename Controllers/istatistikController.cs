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
    [Authorize]
    public class istatistikController : Controller
    {
        Context c = new Context();


        public ActionResult SwertAlert() 
        {
            return View();
        }


        // GET: istatistik
        public ActionResult Index()
        {
            var cariler = c.Concubines.Count().ToString();
            ViewBag.carilerCount = cariler;

            var products = c.Products.Count().ToString();
            ViewBag.productsCount = products;

            var personeller = c.Employees.Count().ToString();
            ViewBag.personellerCount = personeller;

            var kategoriler = c.Categories.Count().ToString();
            ViewBag.kategorilerCount = kategoriler;

            var stoklarToplam = c.Products.Sum(x => x.Stok).ToString();
            ViewBag.stoklarToplam = stoklarToplam;

            var markalar = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.markaCount = markalar;

            var kritikSeviye = c.Products.Count(x => x.Stok <= 20).ToString();
            ViewBag.kritik = kritikSeviye;

            var maxFiyat = (from x in c.Products where x.Status == true orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.maxFiyat = maxFiyat;

            var minFiyat = (from x in c.Products where x.Status == true orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.minFiyat = minFiyat;

            var kediKumu = (from x in c.Products where x.ProductName == "Kedi Kumu" select x.Stok).FirstOrDefault();
            ViewBag.kediKumu = kediKumu;

            var yasMama = (from x in c.Products where x.ProductName == "yaş mama" select x.Stok).FirstOrDefault();
            ViewBag.yasMama = yasMama;

            var TotalkasaTutar = c.salesMoves.Sum(x => x.TotalPrice).ToString();
            ViewBag.TotalkasaTutar = TotalkasaTutar;

            DateTime bugun = DateTime.Today;
            var BugunSatısCount = c.salesMoves.Count(x => x.Date == bugun).ToString();
            ViewBag.BugunSatısCount = BugunSatısCount;


            var BugunSatısTutar = c.salesMoves.Where(x => x.Date == bugun).Sum(y => (decimal?) y.TotalPrice).ToString();
            ViewBag.BugunSatısTutar = BugunSatısTutar;


            var maxMarka = c.Products.GroupBy(x => x.Brand)
                .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.maxMarka = maxMarka;


            var EnCokSatan = c.Products.Where(u => u.ProductID == (c.salesMoves.GroupBy(x => x.ProductID)
                .OrderByDescending(z => z.Count()).Select(y => y.Key)
                .FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.EnCokSatan = EnCokSatan;


            return View();

        }

        public ActionResult BasitTablolar()
        {
            var query = from x in c.Concubines
                         group x by x.City into g
                         select new GroupBy
                         {
                             City = g.Key,
                             Count = g.Count()
                         };

            return View(query.ToList());
        }


        public PartialViewResult Partial1()
        {
            var query = from x in c.Employees
                        group x by x.Department.DepartmentName into g
                        select new GroupBy2
                        {
                            DepartmanName = g.Key,
                            Count = g.Count()
                        };

            return PartialView(query.ToList());

        }

        public PartialViewResult Cariler()
        {
            var values = c.Concubines.ToList();
            return PartialView(values);

        }

        

    }
}