using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucTap_Web_Service.Models;
using Newtonsoft.Json;
using ThucTap_Web_Service.Processors;

namespace ThucTap_Web_Service.Controllers
{
    public class BenhAnController : ApiController
    {

        [HttpPost]
        public string ThemBenhAn([FromBody]BenhAn ba)
        {

            return BenhAnProcessor.ThemBenhAn(ba);
        }

        [HttpPut]
        public string SuaBenhAn([FromBody]BenhAn ba)
        {

            return BenhAnProcessor.SuaBenhAn(ba);
        }

        [HttpGet]
        public string DanhMucBenhAn()
        {
            return JsonConvert.SerializeObject(BenhAnProcessor.DanhMucBenhAn());
        }

        [HttpGet]
        public string ThongTinBenhAn(string id)
        {
            BenhAn ba = BenhAnProcessor.ThongTinBenhAn(id);
            if (ba.Maba == null)
            {
                return "NULL";
            }
            return JsonConvert.SerializeObject(ba);
        }

        [HttpDelete]
        public string XoaBenhAn(string id)
        {
            return BenhAnProcessor.XoaBenhAn(id);
        }
    }
}
