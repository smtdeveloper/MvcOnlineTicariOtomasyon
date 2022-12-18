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
    public class TodoController : Controller
    {
        Context c = new Context();

        // GET: Todo

        public ActionResult Index()
        {
            var values = c.Todos.Where(x => x.IsDelete == false).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult TodoAdd()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult TodoAdd(Todo todo)
        {
            c.Todos.Add(todo);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult TodoSoftDelete(int id)
        {
            var value = c.Todos.Find(id);
           

            if (value.IsDelete)
            {
                value.IsDelete = false;
            }
            else
            {
                value.IsDelete = true;
            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult TodoUpdate(int id)
        {
            var value = c.Todos.Find(id);

            return View("TodoUpdate", value);


        }

        [HttpPost]
        public ActionResult TodoUpdated(Todo todo)
        {
            var value = c.Todos.Find(todo.ID);

            value.Title = todo.Title;
            value.Status = todo.Status;
            value.IsDelete = false;

            c.SaveChanges();

            return RedirectToAction("Index");


        }



    }
}