using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class PSChiTietThuoc
    {
        public int ID { set; get; }
        public string Idpsthuoc { set; get; }
        public string Iddienbien { set; get; }
        public string Mabn { set; get; }
        public string Maba { set; get; }
        public string Makhoa { set; get; }
        public string Mahh { get; set; }
        public double Dongia { get; set; }
        public long Soluong { get; set; }
        public double Thanhtien { set; get; }

        public PSChiTietThuoc() { }
        public PSChiTietThuoc(int id,string idps, string iddb, string mabn, string maba, string makhoa,string mahh ,double dg,long sl,double tt)
        {
            ID = id;
            Idpsthuoc = idps;
            Iddienbien = iddb;
            Mabn = mabn;
            Maba = maba;
            Makhoa = makhoa;
            Mahh = mahh;
            Dongia = dg;
            Soluong = sl;
            Thanhtien = tt;
        }
    }
}