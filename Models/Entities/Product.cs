using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public short Stok { get; set; }
        public decimal BuyingPrice { get; set; } // aldıgın fiyat
        public decimal SalePrice { get; set; } // sattıgın fiyat
        public string ImgUrl { get; set; }
        public string Declaration { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesMove>  SalesMoves { get; set; }
    }
}