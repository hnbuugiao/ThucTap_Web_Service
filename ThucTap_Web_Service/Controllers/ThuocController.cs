using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Processors;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Converters;


namespace ThucTap_Web_Service.Controllers
{
    public class ThuocController : ApiController
    {
        [HttpPost]
        public string ThemThuoc([FromBody]Thuoc thuoc)
        {
            if (thuoc == null)
            {
                return "NULL";
            }
            return ThuocProcessor.AddThuoc(thuoc);
        }

        [HttpGet]
        public List<Thuoc> HienThiThuoc()
        {
            return ThuocProcessor.ShowAllThuoc();
        }

        [HttpGet]
        public string HienThiThuoc(string id)
        {
            Thuoc thuoc = ThuocProcessor.ShowThuoc(id);
            if (thuoc.mahh==null)
            {
                return "NULL";
            }
            else return JsonConvert.SerializeObject(thuoc);
            
        }

        [HttpPut]
        public string SuaThongTin(Thuoc thuoc)
        {
            if (thuoc == null)
            {
                return "NULL";
            }
            return ThuocProcessor.SuaThongTinThuoc(thuoc);
        }


        [HttpDelete]
        public string Xoathuoc(string id)
        {
            if (id == null)
            {
                return "Chưa nhập mã thuốc";
            }
            return ThuocProcessor.XoaThuoc(id);
        }

        [Route("Thuoc/TimKiemMa/{id}")]
        [HttpGet]
        public string TimTheoMaThuoc(string id)
        {
            return JsonConvert.SerializeObject(ThuocProcessor.TimTheoMaThuoc(id));
        }

        [Route("Thuoc/TimKiemTen/{tenthuoc}")]
        [HttpGet]
        public string TimTheoTenThuoc(string tenthuoc)
        {
            /*if (tenthuoc == null)
            {
                return "xin nhập tên thuốc";
            }
            
            else*/
            {
                return JsonConvert.SerializeObject(ThuocProcessor.TimTheoTenThuoc(tenthuoc));
               // return JsonConvert.DeserializeObject<Thuoc>(thuoc);

     
            }


        }

    }
}
