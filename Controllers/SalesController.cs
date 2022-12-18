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
    public class SalesController : Controller
    {
        Context c = new Context();

        // GET: Sales
        public ActionResult Index()
        {
            var values = c.salesMoves.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult SalestAdd()
        {
            List<SelectListItem> employees = (from x in c.Employees.Where(x => x.IsDelete == false).ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.EmployeeFirstName + " " + x.EmployeeLastName,
                                                   Value = x.EmployeeID.ToString()
                                               }).ToList();
            ViewBag.VEmployees = employees;

            List<SelectListItem> concubines = (from x in c.Concubines.Where(x => x.IsDelete == false).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.FirstName + " " + x.LastName,
                                                  Value = x.ConcubineID.ToString()
                                              }).ToList();
            ViewBag.VConcubines = concubines;

            List<SelectListItem> products = (from x in c.Products.Where(x => x.Status == true && x.Stok > 0).ToList()
                                             select new SelectListItem
                                               {
                                                   Text = x.ProductName ,
                                                   Value = x.ProductID.ToString()
                                               }).ToList();
            ViewBag.VProducts = products;


            return View();
        }

        [HttpPost]
        public ActionResult SalestAdd(SalesMove salesMove)
        {
            salesMove.TotalPrice = salesMove.UnitPrice * salesMove.Count;
            c.salesMoves.Add(salesMove);
            c.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}