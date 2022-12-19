using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class FaturaKalemFiltreModel
    {
      
        public IEnumerable<Invoice> Fatura { get; set; }
        public IEnumerable<InvoicePen> FaturaKalem { get; set; }

    }
}