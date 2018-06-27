using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Processors;

namespace ThucTap_Web_Service.Controllers
{
    public class DienBienController: ApiController
    { 
        [HttpPost]
        public string ThemDienBien([FromBody]DienBien dienbien)
        {
            if (dienbien == null)
            {
                return "NULL";
            }
            return DienBienProcessor.AddDienBien(dienbien);
        }

        [HttpPut]
        public string SuaDienBien([FromBody]DienBien dienbien)
        {
            if (dienbien == null)
            {
                return "NULL";
            }
            return DienBienProcessor.SuaThongTinDienBien(dienbien);
        }

        [HttpGet]
        public string HienThiDienBien()
        {
            List<DienBien> listdb = new List<DienBien>();
            listdb = DienBienProcessor.ShowAllDienBien();
            var convertJson = JsonConvert.SerializeObject(listdb);
            return convertJson;
        }

        [HttpGet]
        public string HienThiDienBien(string id)
        {
            DienBien db = new DienBien();
            db = DienBienProcessor.ShowDienBien(id);
            if (db.Iddienbien == null)
                return "NULL";
            var convertJson = JsonConvert.SerializeObject(db);
            return convertJson;
        }

        [HttpDelete]
        public string XoaDienBien(string id)
        {
            if (id == null)
            {
                return "NULL";
            }
            return DienBienProcessor.XoaDienBien(id);
        }
    }

    
}