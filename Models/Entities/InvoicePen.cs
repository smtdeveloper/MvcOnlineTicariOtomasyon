using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class InvoicePen //FaturaKalem
    {
        [Key]
        public int InvoicePenID { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}