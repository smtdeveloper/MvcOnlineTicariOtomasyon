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
    public class DepartmentController : Controller
    {
        Context c = new Context();

        // GET: Department
        public ActionResult Index()
        {
            //var values = c.Departments.Where(x => x.IsDelete == false).ToList();
            var values = c.Departments.ToList();
            return View(values);
        }


        [HttpPost]
        public ActionResult Index(Department department)
        {

            c.Departments.Add(department);
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            return View();

        }

        [HttpPost]
        public ActionResult DepartmentAdd(Department department)
        {

            c.Departments.Add(department);
            c.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult DepartmentDelete(int id)
        {
            var value = c.Departments.Find(id);
            c.Departments.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DepartmentDetay(int id)
        {
            var values = c.Employees.Where(x => x.DepartmentId == id).ToList();
            var value = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.name = value;

            return View(values);

        }


        public ActionResult EmployeeSales(int id)
        {

            var values = c.salesMoves.Where(x => x.EmployeeID == id).ToList();
            var employee = c.Employees.Where(x => x.EmployeeID == id)
                .Select(y => y.EmployeeFirstName + " " + y.EmployeeLastName).FirstOrDefault();

            ViewBag.EmployeeName = employee;
            return View(values);

        }

        public ActionResult DepartmentUpdate(int id)
        {
            var value = c.Departments.Find(id);

            return View("DepartmentUpdate", value);


        }

        [HttpPost]
        public ActionResult DepartmentUpdated(Department department)
        {
            var value = c.Departments.Find(department.DepartmentID);

            value.DepartmentName = department.DepartmentName;
            value.IsDelete = false;

            c.SaveChanges();

            return RedirectToAction("Index");


        }


        public ActionResult ChangeStatusDepartment(int id)
        {
            var value = c.Departments.Find(id);

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

        public ActionResult ChangeStatusEmployee(int employeeID)
        {
            var value = c.Employees.Find(employeeID);

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


    }
}