﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Processors;

namespace ThucTap_Web_Service.Controllers
{
    public class PSCanLamSangController : ApiController
    {
        [HttpPost]
        public string ThemCLS([FromBody]PSCanLamSang PSCanLamSang)
        {
            if (PSCanLamSang == null)
            {
                return "NULL";
            }
            return PSCanLamSangProcessor.AddPSCLS(PSCanLamSang);
        }

        [HttpGet]
        public string HienThiCLS()
        {
            List<PSCanLamSang> list = new List<PSCanLamSang>();
            list =PSCanLamSangProcessor.ShowAllPSCLS();
            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpGet]
        public string HienThiCLS(int id)
        {
           PSCanLamSang list = new PSCanLamSang();
            list =PSCanLamSangProcessor.ShowPSCLS(id);
            if (list.ID == 0)
            {
                return null;
            }
            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpPut]
        public string SuaThongTin([FromBody]PSCanLamSang PSCanLamSang)
        {
            if (PSCanLamSang == null)
            {
                return "NULL";
            }
            return PSCanLamSangProcessor.SuaThongTinPSCLS(PSCanLamSang);
        }


        [HttpDelete]
        public string XoaCLS(int id)
        {
           
            return PSCanLamSangProcessor.XoaPSCLS(id);
        }
    
    }
}
