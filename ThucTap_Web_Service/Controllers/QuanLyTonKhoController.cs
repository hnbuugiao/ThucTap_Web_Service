using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Controllers
{
    public class QuanLyTonKhoController : ApiController
    {
        [Route("PSTonKho/XuatTam")]
        [HttpPost]
        public string XuatTam([FromBody]PSChiTietThuoc pschitietthuoc)
        {
            //return JsonConvert.SerializeObject(pschitietthuoc);
            return QuanLyTonKhoRepository.XuatTam(pschitietthuoc);
        }


        [Route("PSTonKho/PhatThuoc")]
        [HttpPost]
        public string PhatThuoc([FromBody]PSChiTietThuoc pschitietthuoc)
        {
     
            return QuanLyTonKhoRepository.PhatThuoc(pschitietthuoc);
        }
    }

}
