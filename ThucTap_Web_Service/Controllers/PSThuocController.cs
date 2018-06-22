using Newtonsoft.Json;
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
    public class PSThuocController : ApiController
    {
        [HttpPost]
        public string ThemPSThuoc([FromBody]PSThuoc psthuoc)
        {

            return PSThuocProcessor.ThemPSThuoc(psthuoc);
        }

        [HttpPut]
        public string SuaPSThuoc([FromBody]PSThuoc psthuoc)
        {

            return PSThuocProcessor.SuaPSThuoc(psthuoc);
        }

        [HttpGet]
        public string DanhMucPSThuoc()
        {
            return JsonConvert.SerializeObject(PSThuocProcessor.DanhMucPSThuoc());
        }

        [HttpGet]
        public string ThongTinPSThuoc(string id)
        {
            PSThuoc ttpst = PSThuocProcessor.ThongTinPSThuoc(id);
            if (ttpst.Idpsthuoc == null)
            {
                return "NULL";
            }
            return JsonConvert.SerializeObject(ttpst);
        }

        [HttpDelete]
        public string XoaPSThuoc(string id)
        {
            return PSThuocProcessor.XoaPSThuoc(id);
        }
    }
}
