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
    public class NhanVienController : ApiController
    {
        [HttpPost]
        public string ThemNhanVien([FromBody]NhanVien nhanvien)
        {
            if (nhanvien == null)
            {
                return "NULL";
            }
            return NhanVienProcessor.AddNhanVien(nhanvien);
        }

        [HttpGet]
        public string HienThiNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            list = NhanVienProcessor.ShowAllNhanVien();
            var convertedJson = JsonConvert.SerializeObject(list);
            return convertedJson;
        }

        [HttpPost]
        [Route("NhanVien/Check")]
        public bool KiemTraNhanVien(string id,string matkhau)
        {
            //List<NhanVien> list = new List<NhanVien>();
            //list = NhanVienProcessor.ShowNhanVien(id,matkhau);
            bool result = NhanVienProcessor.ShowNhanVien(id, matkhau);

            //var convertedJson = JsonConvert.SerializeObject(list);
            return result?true:false;
        }

        [HttpPut]
        public bool SuaThongTin(NhanVien nhanvien)
        {
            if (nhanvien == null)
            {
                return false;
            }
            return NhanVienProcessor.SuaThongTinNhanVien(nhanvien);
        }

        [HttpDelete]
        public string XoaNhanVien(string id)
        {
            if (id == null)
            {
                return "NULL";
            }
            return NhanVienProcessor.XoaNhanVien(id);
        }
    }
}
