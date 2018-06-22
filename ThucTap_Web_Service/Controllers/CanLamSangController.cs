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
    public class CanLamSangController : ApiController
    {
        [HttpPost]
        public string ThemCLS([FromBody]CanLamSang canlamsan)
        {
            if (canlamsan.macls == ""||canlamsan.tencls ==""||canlamsan.dvt=="")
            {
                return "Chưa nhập đầy đủ thông tin";
            }
            if (canlamsan.dongia <= 0)
            {
                return "đơn giá không hợp lệ";
            }

            return CanLamSangProcessor.AddCLS(canlamsan);


        }

        [HttpGet]
        public string HienThiCLS()
        {
            List<CanLamSang> list = new List<CanLamSang>();
            list = CanLamSangProcessor.ShowAllCLS();
            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpGet]
        public string HienThiCLS(string id)
        {
            CanLamSang list =CanLamSangProcessor.ShowCLS(id);
           // if (list.macls == null)
            //{
             //   return "NULL";
           // }
            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpPut]
        public string SuaThongTin(CanLamSang canlamsan)
        {
            if (canlamsan == null)
            {
                return "NULL";
            }
            return CanLamSangProcessor.SuaThongTinCLS(canlamsan);
        }


        [HttpDelete]
        public string XoaCLS(string id)
        {
            if (id == "")
            {
                return "Chưa nhập id";
            }
            return CanLamSangProcessor.XoaCLS(id);
        }
    }
}
