using ChatApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatApi.Controllers
{
    public class MesajlarController : ApiController
    {
        DB.Chat_MesajlarDataTable dtMesajlar = new DB.Chat_MesajlarDataTable();
        ChatApi.Models.DBTableAdapters.Chat_MesajlarTableAdapter taMesajlar = new Models.DBTableAdapters.Chat_MesajlarTableAdapter();


        public IEnumerable<Mesaj> Get([FromUri]int KanalId)
        {
            dtMesajlar= taMesajlar.GetData(KanalId);
            var mesajlar= new List<Mesaj>(); 

            for (int i = 0; i < dtMesajlar.Count; i++)
            {
                mesajlar.Add(new Mesaj()
                {
                    kID = Convert.ToInt32(dtMesajlar[i]["KullaniciID"].ToString()),
                    kAdi = dtMesajlar[i]["kAdi"].ToString(),
                    Icerik = dtMesajlar[i]["MesajIcerigi"].ToString(),
                    Tarih = Convert.ToDateTime(dtMesajlar[i]["MesajTarihi"].ToString()),
                    KanalId = KanalId
                });

            }
             

            return mesajlar;
        }


        public bool Post([FromBody] Mesaj _mesaj)
        {
            try
            {
                taMesajlar.InsertQuery(_mesaj.kID, _mesaj.Icerik, DateTime.Now,_mesaj.KanalId);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
