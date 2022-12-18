using MvcOnlineTicariOtomasyon.Models.DB;
using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    [Authorize]
    public class ProductController : Controller
    {
        Context c = new Context();

        // GET: Product
        public ActionResult Index()
        {
            var values = c.Products.Where(x => x.Status == true).ToList();
            return View(values);

        }

        [HttpGet]
        public ActionResult MakeSale(int id) 
        {
            List<SelectListItem> employees = (from x in c.Employees.Where(x => x.IsDelete == false).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.EmployeeFirstName + " " + x.EmployeeLastName,
                                                  Value = x.EmployeeID.ToString()
                                              }).ToList();
            ViewBag.VEmployees = employees;

            var entity = c.Products.Find(id);
            ViewBag.VProductID = entity.ProductID;
            ViewBag.VProductSalePrice = entity.SalePrice;

            var TodayDate = DateTime.Today.ToShortDateString();
            ViewBag.VToday = TodayDate;

            return View();
        }

        [HttpPost]
        public ActionResult MakeSale(SalesMove salesMove)
        {
           
            c.salesMoves.Add(salesMove);
            c.SaveChanges();

            return RedirectToAction("Index" , "Sales");
        }



        public ActionResult ProductListPdf()
        {
            var values = c.Products.Where(x => x.Status == true).ToList();
            return View(values);

        }


        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> categories = (from x in c.Categories.Where(x=> x.IsDelete == false).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.value = categories;

            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            c.Products.Add(product);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ProductUpdate(int id)
        {
            List<SelectListItem> categories = (from x in c.Categories.Where(x => x.IsDelete == false).ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.value = categories;


            var value = c.Products.Find(id);

            return View("ProductUpdate", value);


        }

        [HttpPost]
        public ActionResult ProductUpdated(Product product)
        {
            var value = c.Products.Find(product.ProductID);

            value.ProductName = product.ProductName;
            value.Brand = product.Brand;
            value.Stok = product.Stok;
            value.BuyingPrice = product.BuyingPrice;
            value.SalePrice = product.SalePrice;
            value.ImgUrl = product.ImgUrl;
            value.Status = product.Status;
            value.CategoryId = product.CategoryId;
            

            c.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}