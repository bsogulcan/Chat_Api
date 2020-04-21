using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApi.Models
{
    public class Kanal
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public int OlusturanKId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}