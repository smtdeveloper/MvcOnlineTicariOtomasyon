﻿using System;
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
        public string ConcubineFirstName { get; set; }
        public string ConcubinesLastName { get; set; }
        public string ConcubinesCity { get; set; }
        public string ConcubinesMail { get; set; }

        public ICollection<SalesMove> SalesMoves { get; set; }  
    }
}