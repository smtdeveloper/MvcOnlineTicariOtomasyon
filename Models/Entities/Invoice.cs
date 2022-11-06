using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Invoice // fatura
    {
        [Key]
        public int InvoiceID { get; set; }
        public string InvoiceSerialNumber { get; set; } //Fatura Seri No
        public string InvoiceSequenceNo { get; set; } //Sequence No
        public string TaxAdministration { get; set; } //VergiDairesi
        public string Submitter { get; set; } //Submitter Teslim Eden
        public string DeliveryArea { get; set; } //DeliveryArea Teslim Alan
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }

        public ICollection<InvoicePen> InvoicePens { get; set; }
    }
}