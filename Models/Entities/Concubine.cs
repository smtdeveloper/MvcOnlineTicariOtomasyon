using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Concubine
    {
        [Key]
        public int ConcubineID { get; set; }
        [Required (ErrorMessage = "Bu Alan Boş Gecilemez ! ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Gecilemez ! ")]
        public string LastName { get; set; }
        public string City { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<SalesMove> SalesMoves { get; set; }  
    }
}