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
    public class ToaThuocController : ApiController
    {
        [Route("ToaThuoc/LuuToa/")]
        [HttpPost]
        public string LuuToa([FromBody]PSThuoc psthuoc, List<PSChiTietThuoc> psctthuoc)
        {

            return ToaThuocRepository.NhapToaThuoc(psthuoc, psctthuoc);
        }
    }
}
