using MvcOnlineTicariOtomasyon.Models.DB;
using MvcOnlineTicariOtomasyon.Models.Entities;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = "A")]
    [Authorize]
    public class CargoController : Controller
    {

        Context c = new Context();

        // GET: Cargo
        public ActionResult Index(string p)
        {
            var values = from x in c.cargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.TakipKodu.Contains(p));
            }



            return View(values.ToList());

        }

        
        [HttpGet]
        public ActionResult CargoAdd()
        {
            Random rnd = new Random();
            string[] chars = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);

            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string kod = s1.ToString() + chars[k1] + s2.ToString() + chars[k2] + s3.ToString() + chars[k3];
            ViewBag.takipKod = kod;
            return View();

        }

        [HttpPost]
        public ActionResult CargoAdd(CargoDetay cargoDetay)
        {

            c.cargoDetays.Add(cargoDetay);
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult CargoTakip(string id)
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