using MvcOnlineTicariOtomasyon.Models.DB;
using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();


        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            //var values = c.Categories.Where(x => x.IsDelete == false).ToList();
            var values = c.Categories.ToList();
            return View(values);

        }

        [HttpPost]
        public ActionResult Index(Category category)
        {

            c.Categories.Add(category);
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {

            c.Categories.Add(category);
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        
        public ActionResult CategoryDelete(int id)
        {
            var value = c.Categories.Find(id);
            c.Categories.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

      
        public ActionResult CategoryUpdate(int id)
        {
            var value = c.Categories.Find(id);

            return View("CategoryUpdate" , value);


        }

        [HttpPost]
        public ActionResult CategoryUpdated(Category category)
        {
            var value = c.Categories.Find(category.CategoryID);

            value.CategoryName = category.CategoryName;
            value.IsDelete = false;

            c.SaveChanges();

            return RedirectToAction("Index");


        }



    }
}