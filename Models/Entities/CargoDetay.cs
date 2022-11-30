using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class CargoDetay
    {
        [Key]
        public int CargoDetayID { get; set; }
        public string Aciklama { get; set; }
        public string TakipKodu { get; set; }
        public string Employee { get; set; }
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }

    }
}