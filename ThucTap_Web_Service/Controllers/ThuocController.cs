using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Processors;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Converters;


namespace ThucTap_Web_Service.Controllers
{
    public class ThuocController : ApiController
    {
        [HttpPost]
        public string ThemThuoc([FromBody]Thuoc thuoc)
        {
            if (thuoc == null)
            {
                return "NULL";
            }
            return ThuocProcessor.AddThuoc(thuoc);
        }

        [HttpGet]
        public string HienThiThuoc()
        {
            List<Thuoc> list = new List<Thuoc>();
            list = ThuocProcessor.ShowAllThuoc();
            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpGet]
        public string HienThiThuoc(string id)
        {
            List<Thuoc> list = new List<Thuoc>();
            list = ThuocProcessor.ShowThuoc(id);

            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpPut]
        public bool SuaThongTin(Thuoc thuoc)
        {
            if (thuoc == null)
            {
                return false;
            }
            return ThuocProcessor.SuaThongTinThuoc(thuoc);
        }


        [HttpDelete]
        public bool Xoathuoc(string id)
        {
            if (id == null)
            {
                return false;
            }
            return ThuocProcessor.XoaThuoc(id);
        }
    }
}
