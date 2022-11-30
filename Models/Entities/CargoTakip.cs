using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class CargoTakip
    {
        [Key]
        public int CargoTakipID { get; set; }
        public string TakipKodu { get; set; }
        public string Aciklama { get; set; }
        public DateTime Date { get; set; }
    }
}