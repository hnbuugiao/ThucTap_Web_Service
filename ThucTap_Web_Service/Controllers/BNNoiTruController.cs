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
    public class BNNoiTruController : ApiController
    {
        [HttpPost]
        public string ThemBNNoiTru([FromBody]BNNoiTru BNNoiTru)
        {
            if (BNNoiTru == null)
            {
                return "NULL";
            }
            return BNNoiTruProcessor.ThemBNNoiTru(BNNoiTru);
        }

        [HttpPut]
        public string SuaBNNoiTru([FromBody]BNNoiTru BNNoiTru)
        {

            return BNNoiTruProcessor.SuaBNNoiTru(BNNoiTru);
        }

        [HttpGet]
        public List<BNNoiTru> DanhMucBNNoiTru()
        {
            return BNNoiTruProcessor.DanhMucBNNoiTru();
        }

        [HttpGet]
        public BNNoiTru ThongTinBNNoiTru(int id)
        {
            return BNNoiTruProcessor.ThongTinBNNoiTru(id);
        }

        [HttpDelete]
        public string XoaBNNoiTru(int id)
        {
            return BNNoiTruProcessor.XoaBNNoiTru(id);
        }
    }
}
