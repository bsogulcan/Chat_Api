using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApi.Models
{
    public class Mesaj
    {
        public int kID { get; set; }
        public string kAdi { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public int KanalId { get; set; }
    }
}