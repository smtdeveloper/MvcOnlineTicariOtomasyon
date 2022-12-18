using MvcOnlineTicariOtomasyon.Models.DB;
using MvcOnlineTicariOtomasyon.Models.Entities;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcOnlineTicariOtomasyon.Models;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    [Authorize]
    public class CategoryController : Controller
    {
        Context c = new Context();


        // GET: Category
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            //var values = c.Categories.Where(x => x.IsDelete == false).ToList();
            var values = c.Categories.ToList().ToPagedList(page, 6);
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

            return RedirectToAction("CategoryAdd");

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

            return View("CategoryUpdate", value);


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


        public ActionResult ChangeStatusCategory(int id)
        {
            var blogValue = c.Categories.Find(id);

            if (blogValue.IsDelete)
            {
                blogValue.IsDelete = false;
            }
            else
            {
                blogValue.IsDelete = true;
            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }

      

        public ActionResult Deneme()
        {

            CategoryFiltreModel model = new CategoryFiltreModel();
            model.Categories = new SelectList(c.Categories, "CategoryID", "CategoryName");
            model.Categories = new SelectList(c.Products, "ProductID", "ProductName");
            return View(model);

        }

        public JsonResult UrunGetir(int p)
        {
            var urunlistesi = (from x in c.Products
                               join y in c.Categories
                               on x.Category.CategoryID equals y.CategoryID
                               where x.Category.CategoryID == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductID.ToString()
                               }).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet);

        }

    }
}