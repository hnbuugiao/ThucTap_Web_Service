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
    public class PSTonKhoController : ApiController
    {
        [HttpPost]
        public string ThemPSTonKho([FromBody]PSTonKho psTonKho)
        {
            if (psTonKho == null)
            {
                return "NULL";
            }
            return PSTonKhoProcessor.ThemPSTonKho(psTonKho);
        }

        [HttpPut]
        public string SuaPSTonKho([FromBody]PSTonKho psTonKho)
        {

            return PSTonKhoProcessor.SuaPSTonKho(psTonKho);
        }

        [HttpGet]
        public List<PSTonKho> DanhMucPSTonKho()
        {
            return PSTonKhoProcessor.DanhMucPSTonKho();
        }

        [HttpGet]
        public PSTonKho ThongTinPSTonKho(int id)
        {
            return PSTonKhoProcessor.ThongTinPSTonKho(id);
        }

        [HttpDelete]
        public string XoaPSTonKho(int id)
        {
            return PSTonKhoProcessor.XoaPSTonKho(id);
        }
    }
}
