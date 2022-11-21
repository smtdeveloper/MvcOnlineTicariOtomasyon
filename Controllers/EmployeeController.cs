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
    public class EmployeeController : Controller
    {
        Context c = new Context();

        // GET: Employee
        public ActionResult Index()
        {
            var values = c.Employees.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EmployeeAdd()
        {

            List<SelectListItem> employees = (from x in c.Departments.Where(x => x.IsDelete == false).ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentID.ToString()
                                               }).ToList();
            ViewBag.Values = employees;
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeAdd(Employee employee)
        {
            c.Employees.Add(employee);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EmployeeUpdate(int id)
        {
            var value = c.Employees.Find(id);
            List<SelectListItem> employees = (from x in c.Departments.Where(x => x.IsDelete == false).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmentName,
                                                  Value = x.DepartmentID.ToString()
                                              }).ToList();
            ViewBag.Values = employees;
            return View("EmployeeUpdate", value);
        }

        [HttpPost]
        public ActionResult EmployeeUpdate(Employee employee)
        {
            var value = c.Employees.Find(employee.EmployeeID);

            value.EmployeeFirstName = employee.EmployeeFirstName;
            value.EmployeeLastName = employee.EmployeeLastName;
            value.EmployeeImg = employee.EmployeeImg;
            value.DepartmentId = employee.DepartmentId;
            value.IsDelete = employee.IsDelete;

            c.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}