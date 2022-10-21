using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Authority { get; set; } // YETKİ
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}