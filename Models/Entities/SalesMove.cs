using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class SalesMove
    {
        [Key]
        public int SalesMoveID { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }

        public int ProductID { get; set; }
        public int ConcubineID { get; set; }
        public int EmployeeID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Concubine Concubine{ get; set; }
        public virtual Employee Employee { get; set; }

    }
}