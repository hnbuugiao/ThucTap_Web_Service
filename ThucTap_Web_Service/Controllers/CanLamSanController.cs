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
    public class CanLamSanController : ApiController
    {
        [HttpPost]
        public string ThemCLS([FromBody]CanLamSan canlamsan)
        {
            if (canlamsan == null)
            {
                return "NULL";
            }
            return CanLamSanProcessor.AddCLS(canlamsan);
        }

        [HttpGet]
        public string HienThiCLS()
        {
            List<CanLamSan> list = new List<CanLamSan>();
            list = CanLamSanProcessor.ShowAllCLS();
            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpGet]
        public string HienThiCLS(string id)
        {
            List<CanLamSan> list = new List<CanLamSan>();
            list = CanLamSanProcessor.ShowCLS(id);

            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpPut]
        public bool SuaThongTin(CanLamSan canlamsan)
        {
            if (canlamsan == null)
            {
                return false;
            }
            return CanLamSanProcessor.SuaThongTinCLS(canlamsan);
        }


        [HttpDelete]
        public bool XoaCLS(string id)
        {
            if (id == null)
            {
                return false;
            }
            return CanLamSanProcessor.XoaCLS(id);
        }
    }
}
