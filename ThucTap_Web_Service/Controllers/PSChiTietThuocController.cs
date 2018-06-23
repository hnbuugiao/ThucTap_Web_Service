using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Processors;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Controllers
{
    public class PSChiTietThuocController : ApiController
    {

        [Route("PSChiTietThuoc/XuatTam")]
        [HttpPost]
        public string XuatTam([FromBody]PSChiTietThuoc pschitietthuoc)
        {
           // return JsonConvert.SerializeObject(pschitietthuoc);
            return QuanLyTonKhoRepository.XuatTam(pschitietthuoc);
        }

        [HttpPost]
        public string ThemPSChiTietThuoc([FromBody]PSChiTietThuoc pschitietthuoc)
        {
            //return JsonConvert.SerializeObject(pschitietthuoc);
            return PSChiTietThuocProcessor.ThemPSChiTietThuoc(pschitietthuoc);
        }

        [HttpPut]
        public string SuaPSChiTietThuoc([FromBody]PSChiTietThuoc pschitietthuoc)
        {

            return PSChiTietThuocProcessor.SuaPSChiTietThuoc(pschitietthuoc);
        }

        [HttpGet]
        public string DanhMucPSChiTietThuoc()
        {
            return JsonConvert.SerializeObject(PSChiTietThuocProcessor.DanhMucPSChiTietThuoc());
        }

        [HttpGet]
        public string ThongTinPSChiTietThuoc(int id)
        {
            PSChiTietThuoc psctt = PSChiTietThuocProcessor.ThongTinPSChiTietThuoc(id);
            if (psctt.ID == 0)
            {
                return "NULL";
            }
            return JsonConvert.SerializeObject(psctt);
        }

        [HttpDelete]
        public string XoaPSChiTietThuoc(int id)
        {
            return PSChiTietThuocProcessor.XoaPSChiTietThuoc(id);
        }
    }
}
