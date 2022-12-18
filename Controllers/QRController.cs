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
    public class QRController : Controller
    {
        // GET: QR
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string kod)
        {
            using( MemoryStream ms = new MemoryStream() ) 
            {
                QRCodeGenerator CreateCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = CreateCode.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);

                using( Bitmap resim = karekod.GetGraphic(10) ) 
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodiresim = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }

    }
}