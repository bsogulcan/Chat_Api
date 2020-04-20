using ChatApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatApi.Controllers
{
    public class GirisYapController : ApiController
    {
        ChatApi.Models.DB.Chat_KullanicilarDataTable dtKullanici = new DB.Chat_KullanicilarDataTable();
        ChatApi.Models.DBTableAdapters.Chat_KullanicilarTableAdapter taKullanici = new Models.DBTableAdapters.Chat_KullanicilarTableAdapter();


        public int Post([FromBody]Session _session)
        {
            int kID = KullaniciSorgula(_session.kAdi, _session.kSifre);
            return kID;

        }
        int KullaniciSorgula(string kAdi, string kSifre)
        {
            dtKullanici = taKullanici.SPKullaniciSorgula(kAdi, kSifre);
            if (dtKullanici.Count > 0)
            {
                return Convert.ToInt32(dtKullanici.Rows[0]["Id"].ToString());
            } else
            {
                return -1;
            }
        }
         
    }
}
