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
        public string DanhMucPSTonKho()
        {
            return JsonConvert.SerializeObject(PSTonKhoProcessor.DanhMucPSTonKho());
        }

        [HttpGet]
        public string ThongTinPSTonKho(int id)
        {
            PSTonKho pstk = PSTonKhoProcessor.ThongTinPSTonKho(id);
            if (pstk.ID == 0)
            {
                return "NULL";
            }
            return JsonConvert.SerializeObject(pstk);
        }

        [HttpDelete]
        public string XoaPSTonKho(int id)
        {
            return PSTonKhoProcessor.XoaPSTonKho(id);
        }
    }
}
