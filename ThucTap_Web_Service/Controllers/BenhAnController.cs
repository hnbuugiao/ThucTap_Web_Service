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
        public List<BenhAn> DanhMucBenhAn()
        {
            return BenhAnProcessor.DanhMucBenhAn();
        }

        [HttpGet]
        public BenhAn ThongTinBenhAn(string id)
        {
            return BenhAnProcessor.ThongTinBenhAn(id);
        }

        [HttpDelete]
        public string XoaBenhAn(string id)
        {
            return BenhAnProcessor.XoaBenhAn(id);
        }
    }
}
