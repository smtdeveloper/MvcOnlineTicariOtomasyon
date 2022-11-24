using MvcOnlineTicariOtomasyon.Models.DB;
using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    
    public class LoginController : Controller
    {
        Context c = new Context();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin(Concubine concubine)
        {
            var login = c.Concubines.FirstOrDefault(x => x.Mail == concubine.Mail && x.Password == concubine.Password);
            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.Mail, false);

                Session["CariEmail"] = login.Mail.ToString();

                return RedirectToAction("Index", "ConcubinePanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }


        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var login = c.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.UserName, false);

                Session["UserName"] = login.UserName.ToString();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

    }
}