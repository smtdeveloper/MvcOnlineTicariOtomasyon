using MvcOnlineTicariOtomasyon.Models.DB;
using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class RegisterController : Controller
    {
        Context c = new Context();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariRegister(Concubine concubine)
        {
            c.Concubines.Add(concubine);
            c.SaveChanges();
            return RedirectToAction("Index", "Login");

        }

    }
}