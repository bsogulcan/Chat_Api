using ChatApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatApi.Controllers
{
    public class KanallarController : ApiController
    {
        DB.Chat_KanalDataTable dtKanal = new DB.Chat_KanalDataTable();
        Models.DBTableAdapters.Chat_KanalTableAdapter taKanal = new Models.DBTableAdapters.Chat_KanalTableAdapter();
        public IEnumerable<Kanal> Get()
        {
            var _kanal = new List<Kanal>(); ;

            dtKanal = taKanal.GetData();
            for (int i = 0; i < dtKanal.Count; i++)
            {
                _kanal.Add(new Kanal { 
                    Id= Convert.ToInt32(dtKanal[i]["Id"].ToString()),
                    Baslik =dtKanal[i]["Baslik"].ToString(),
                    OlusturanKId=Convert.ToInt32(dtKanal[i]["OlusturanKId"].ToString()),
                    OlusturmaTarihi= Convert.ToDateTime( dtKanal[i]["Tarih"].ToString())
                });;
            }


            return _kanal;
        }
    }
}
