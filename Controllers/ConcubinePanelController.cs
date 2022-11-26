using MvcOnlineTicariOtomasyon.Models.DB;
using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class ConcubinePanelController : Controller
    {

        Context c = new Context();

        // GET: ConcubinePanel
        public ActionResult Index()
        {
            //var email = (string)Session["CariEmail"];
            //var values = c.Concubines.FirstOrDefault(x => x.Mail == email);
            //ViewBag.mail = email;
            
            var mail = User.Identity.Name;
            var concubineID = c.Concubines.Where(x => x.Mail == mail).Select(y => y.ConcubineID).FirstOrDefault();

            var fullName = c.Concubines.Where(x => x.Mail == mail).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.VfullName = fullName;

            var values = c.Concubines.Where(x => x.ConcubineID == concubineID & x.IsDelete == false).ToList();
            return View(values);

        }

        public ActionResult Orders() 
        {
            var mail = User.Identity.Name;
            var concubineID = c.Concubines.Where(x => x.Mail == mail).Select(y => y.ConcubineID).FirstOrDefault();

            var values = c.salesMoves.Where(x => x.ConcubineID == concubineID).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewParola(int id)
        {
            var value = c.Concubines.Find(id);

            return View("NewParola", value);
        }

        [HttpPost]
        public ActionResult NewParola(Concubine concubine) 
        {
            if (!ModelState.IsValid)
            {
                return View("NewParola");
            }

            var value = c.Concubines.Find(concubine.ConcubineID);

            value.FirstName = concubine.FirstName;
            value.LastName = concubine.LastName;
            value.City = concubine.City;
            value.Mail = concubine.Mail;
            value.IsDelete = concubine.IsDelete;
            value.Password = concubine.Password;

            c.SaveChanges();

        

            return RedirectToAction("Index");
        }


        

    }
}