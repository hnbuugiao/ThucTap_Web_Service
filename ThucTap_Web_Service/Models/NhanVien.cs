using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class NhanVien
    {
        public string manv { get; set; }
        public string hoten { get; set; }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }

        public NhanVien()
        {

        }

        public NhanVien(string manv, string hoten, string taikhoan, string matkhau)
        {
            this.manv = manv;
            this.hoten = hoten;
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
        }
    }
}