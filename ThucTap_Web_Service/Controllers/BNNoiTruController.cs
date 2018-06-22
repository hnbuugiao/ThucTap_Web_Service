using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Processors;

namespace ThucTap_Web_Service.Controllers
{
    public class BNNoiTruController : ApiController
    {
        [HttpPost]
        public string ThemBNNoiTru([FromBody]BNNoiTru BNNoiTru)
        {
            if (BNNoiTru.Mabn == "")
            {
                return "Chưa nhập mã bệnh nhân";
            }
            if (BNNoiTru.Maba == "")
            {
                return "Chua nhập mã bệnh án";
            }
            if (BNNoiTru.Makhoa == "")
            {
                return "Chưa nhập mã khoa";
            }
            return BNNoiTruProcessor.ThemBNNoiTru(BNNoiTru);
        }

        [HttpPut]
        public string SuaBNNoiTru([FromBody]BNNoiTru BNNoiTru)
        {

            return BNNoiTruProcessor.SuaBNNoiTru(BNNoiTru);
        }

        [HttpGet]
        public string DanhMucBNNoiTru()
        {
            return JsonConvert.SerializeObject(BNNoiTruProcessor.DanhMucBNNoiTru());
        }

        [HttpGet]
        public string ThongTinBNNoiTru(int id)
        {
            BNNoiTru bn = BNNoiTruProcessor.ThongTinBNNoiTru(id);
            if (bn.Mabn == null)
            {
                return "NULL";
            }
            
            return JsonConvert.SerializeObject(bn);
        }

        [HttpDelete]
        public string XoaBNNoiTru(int id)
        {
            return BNNoiTruProcessor.XoaBNNoiTru(id);
        }
    }
}
