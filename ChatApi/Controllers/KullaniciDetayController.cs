using ChatApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatApi.Controllers
{
    public class KullaniciDetayController : ApiController
    {
        ChatApi.Models.DB.Chat_KullanicilarDataTable dtKullanici = new DB.Chat_KullanicilarDataTable();
        ChatApi.Models.DBTableAdapters.Chat_KullanicilarTableAdapter taKullanici = new Models.DBTableAdapters.Chat_KullanicilarTableAdapter();
        public Session Post([FromBody]Session session)
        {
            Session _session = new Session();
            dtKullanici = taKullanici.SPKullaniciGetir(session.kAdi);
            if (dtKullanici.Count > 0)
            {
                _session.kAdi = dtKullanici[0]["kAdi"].ToString();
                byte[] kFoto = (byte[])dtKullanici[0]["kFoto"];
                string base64String = Convert.ToBase64String(kFoto, 0, kFoto.Length); 
                _session.kFoto = base64String;
            } 
            return _session; 
        }

    }
}
