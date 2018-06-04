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
    public class PSChiTietThuocController : ApiController
    {

        [HttpPost]
        public string ThemPSChiTietThuoc([FromBody]PSChiTietThuoc pschitietthuoc)
        {

            return PSChiTietThuocProcessor.ThemPSChiTietThuoc(pschitietthuoc);
        }

        [HttpPut]
        public string SuaPSChiTietThuoc([FromBody]PSChiTietThuoc pschitietthuoc)
        {

            return PSChiTietThuocProcessor.SuaPSChiTietThuoc(pschitietthuoc);
        }

        [HttpGet]
        public List<PSChiTietThuoc> DanhMucPSChiTietThuoc()
        {
            return PSChiTietThuocProcessor.DanhMucPSChiTietThuoc();
        }

        [HttpGet]
        public PSChiTietThuoc ThongTinPSChiTietThuoc(int id)
        {
            return PSChiTietThuocProcessor.ThongTinPSChiTietThuoc(id);
        }

        [HttpDelete]
        public string XoaPSChiTietThuoc(int id)
        {
            return PSChiTietThuocProcessor.XoaPSChiTietThuoc(id);
        }
    }
}
