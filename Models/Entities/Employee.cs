using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeImg { get; set; }

        public ICollection<SalesMove> SalesMoves { get; set; }
        public Department Department { get; set; }

    }
}