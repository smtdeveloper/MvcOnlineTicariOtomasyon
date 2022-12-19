using MvcOnlineTicariOtomasyon.Models;
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
    public class InvoiceController : Controller
    {

        Context c = new Context();

        // GET: Invoice
        public ActionResult Index()
        {
            var values = c.Invoices.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();

        }

        [HttpPost]
        public ActionResult InvoiceAdd(Invoice invoice)
        {

            c.Invoices.Add(invoice);
            c.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult InvoiceUpdate(int id)
        {
            var value = c.Invoices.Find(id);

            return View("InvoiceUpdate", value);


        }

        [HttpPost]
        public ActionResult InvoiceUpdate(Invoice invoice)
        {
            var value = c.Invoices.Find(invoice.InvoiceID);

            value.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            value.InvoiceSequenceNo = invoice.InvoiceSerialNumber;
            value.TaxAdministration = invoice.TaxAdministration;
            value.Date = invoice.Date;
            value.Submitter = invoice.Submitter;
            value.DeliveryArea = invoice.DeliveryArea;
            value.TotalPrice = invoice.TotalPrice;
          

            c.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult InvoicePenDetay(int id) 
        {
            var values = c.InvoicePens.Where(x => x.InvoiceID == id).ToList();
           

            return View(values);
        }

        [HttpGet]
        public ActionResult InvoicePenAdd() 
        {
            List<SelectListItem> invoices = (from x in c.Invoices.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = "ID : "+ x.InvoiceID + " - Teslim Eden :  " + x.Submitter + " Teslim Alan : " + x.DeliveryArea,
                                                  Value = x.InvoiceID.ToString()
                                              }).ToList();
            ViewBag.Values = invoices;
            return View();
        }

        [HttpPost]
        public ActionResult InvoicePenAdd(InvoicePen  invoicePen)
        {
            invoicePen.TotalPrice = invoicePen.Count * invoicePen.UnitPrice;
            
            c.InvoicePens.Add(invoicePen);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DinamikInvoice() 
        {
            FaturaKalemFiltreModel model = new FaturaKalemFiltreModel();
            model.Fatura = c.Invoices.ToList();
            model.FaturaKalem = c.InvoicePens.ToList();

            return View(model);

        }


        public ActionResult DinamikInvoiceSave(string InvoiceSerialNumber, string InvoiceSequenceNo, string TaxAdministration, 
            string Submitter, string DeliveryArea, DateTime Date, string TotalPrice , InvoicePen[] invoicePens) 
        {
            Invoice ınvoice = new Invoice();
            ınvoice.InvoiceSerialNumber = InvoiceSerialNumber;
            ınvoice.InvoiceSequenceNo = InvoiceSequenceNo;
            ınvoice.TaxAdministration = TaxAdministration;
            ınvoice.Submitter = Submitter;
            ınvoice.DeliveryArea = DeliveryArea;
            ınvoice.Date = Date;
            ınvoice.TotalPrice = decimal.Parse(TotalPrice);

            c.Invoices.Add(ınvoice);

            foreach (var item in invoicePens)
            {
                InvoicePen pen = new InvoicePen();
                pen.Description = item.Description;
                pen.UnitPrice = item.UnitPrice;
                pen.InvoiceID = item.InvoiceID;
                pen.Count = item.Count;
                pen.TotalPrice = item.TotalPrice;
                c.InvoicePens.Add(pen);

            }

            c.SaveChanges();

            return Json("İşlem Başarılı, Eklendi", JsonRequestBehavior.AllowGet);


        }

    }
}