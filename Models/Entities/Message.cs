using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public string GöndereciMail { get; set; }
        public string AlıcıMail { get; set; }
        public string Title { get; set; }
        public string Mesaj { get; set; }
        public DateTime Date { get; set; }

    }
}