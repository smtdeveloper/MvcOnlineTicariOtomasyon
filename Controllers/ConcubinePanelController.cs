using MvcOnlineTicariOtomasyon.Models.DB;
using MvcOnlineTicariOtomasyon.Models.Entities;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

            var cariID = c.Concubines.Where(x => x.Mail == mail).Select(y => y.ConcubineID).FirstOrDefault();
            var totalSalesCount = c.salesMoves.Where(x => x.ConcubineID == cariID).Count();
            ViewBag.VTotalSalesCount = totalSalesCount;

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

        public ActionResult IncomingMessage()
        {
            var mail = User.Identity.Name;
            var values = c.Messages.Where(x => x.AlıcıMail == mail).ToList();

            var gelenMailCount = c.Messages.Count(x => x.AlıcıMail == mail).ToString();
            ViewBag.VGelenMailCount = gelenMailCount;

            var gidenMailCount = c.Messages.Count(x => x.GöndereciMail == mail).ToString();
            ViewBag.VGidenMailCount = gidenMailCount;

            return View(values);

        }

        public ActionResult OutgoingMessage()
        {
            var mail = User.Identity.Name;
            var values = c.Messages.Where(x => x.GöndereciMail == mail).ToList();

            var gidenMailCount = c.Messages.Count(x => x.GöndereciMail == mail).ToString();
            ViewBag.VGidenMailCount = gidenMailCount;

            var gelenMailCount = c.Messages.Count(x => x.AlıcıMail == mail).ToString();
            ViewBag.VGelenMailCount = gelenMailCount;
            return View(values);

        }

        public ActionResult MesssageDetail(int id)
        {
            var values = c.Messages.Where(x => x.MessageID == id).ToList();

            var mail = User.Identity.Name;
            var gidenMailCount = c.Messages.Count(x => x.GöndereciMail == mail).ToString();
            ViewBag.VGidenMailCount = gidenMailCount;

            var gelenMailCount = c.Messages.Count(x => x.AlıcıMail == mail).ToString();
            ViewBag.VGelenMailCount = gelenMailCount;

            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {

            var mail = User.Identity.Name;
            var gidenMailCount = c.Messages.Count(x => x.GöndereciMail == mail).ToString();
            ViewBag.VGidenMailCount = gidenMailCount;

            var gelenMailCount = c.Messages.Count(x => x.AlıcıMail == mail).ToString();
            ViewBag.VGelenMailCount = gelenMailCount;

            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = User.Identity.Name;

            message.Date = DateTime.Parse(DateTime.Now.ToLongTimeString());
            message.GöndereciMail = mail;

            Thread.Sleep(2000);

            c.Messages.Add(message);
            c.SaveChanges();
            return View();
        }

        public ActionResult Cargo(string p)
        {
            var values = from x in c.cargoDetays select x;
            values = values.Where(y => y.TakipKodu.Contains(p));
            return View(values.ToList());
        }

        [HttpGet]
        public ActionResult CargoDetail(string id)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator CreateCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = CreateCode.CreateQrCode(id, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap resim = karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodiresim = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            var values = c.cargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(values);

        }



    }
}