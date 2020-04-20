using ChatApi.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatApi.Controllers
{
    public class KayitOlController : ApiController
    {
        ChatApi.Models.DB.Chat_KullanicilarDataTable dtKullanici = new DB.Chat_KullanicilarDataTable();
        ChatApi.Models.DBTableAdapters.Chat_KullanicilarTableAdapter taKullanici = new Models.DBTableAdapters.Chat_KullanicilarTableAdapter();

        public bool Post([FromBody]Session _session)
        {
            if (KayitOl(_session.kAdi, _session.kSifre,_session.kFoto))
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
        Boolean KayitOl(string kAdi,string kSifre, string kFoto)
        {
            Byte[] bytes = Convert.FromBase64String(kFoto);
            dtKullanici = taKullanici.SPKullaniciSorgula(kAdi, kSifre);
            if (dtKullanici.Count>0)
            {
                return false;
            }
            else
            {
                taKullanici.InsertQuery(kAdi,kSifre, bytes);
            }
            return true;
        }

    }
}

