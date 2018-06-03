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
        public List<PSThuoc> DanhMucPSThuoc()
        {
            return PSThuocProcessor.DanhMucPSThuoc();
        }

        [HttpGet]
        public PSThuoc ThongTinPSThuoc(string id)
        {
            return PSThuocProcessor.ThongTinPSThuoc(id);
        }

        [HttpDelete]
        public string XoaPSThuoc(string id)
        {
            return PSThuocProcessor.XoaPSThuoc(id);
        }
    }
}
