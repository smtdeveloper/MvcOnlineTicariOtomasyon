﻿using MvcOnlineTicariOtomasyon.Models.DB;
using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ConcubineController : Controller
    {

        Context c = new Context();

        // GET: Concubine
        public ActionResult Index()
        {
            var values = c.Concubines.Where(x => x.IsDelete == false).ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult ConcubineAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConcubineAdd(Concubine concubine)
        {
            c.Concubines.Add(concubine);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        
        public ActionResult ConcubineDelete(int id)
        {
            var value = c.Concubines.Find(id);
            value.IsDelete = true;

            c.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult ConcubineUpdate(int id)
        {
            var value = c.Concubines.Find(id);

            return View("ConcubineUpdate", value);


        }

        [HttpPost]
        public ActionResult ConcubineUpdate(Concubine concubine)
        {
            if (!ModelState.IsValid)
            {
                return View("ConcubineUpdate");
            }

            var value = c.Concubines.Find(concubine.ConcubineID);

            value.ConcubineFirstName = concubine.ConcubineFirstName;
            value.ConcubinesLastName = concubine.ConcubinesLastName;
            value.ConcubinesCity = concubine.ConcubinesCity;
            value.ConcubinesMail = concubine.ConcubinesMail;
            value.IsDelete = false;

            c.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult CustomerSales(int id)
        {

            var values = c.salesMoves.Where(x => x.ConcubineID == id).ToList();
            var cariName = c.Concubines.Where(x => x.ConcubineID == id).Select(y => y.ConcubineFirstName + " " + y.ConcubinesLastName).FirstOrDefault();
            ViewBag.VCariName = cariName;


            return View(values);

        }


    }
}