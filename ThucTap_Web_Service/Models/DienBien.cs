using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class DienBien
    {
        public string Iddienbien { get; set; }
        public string Maba { get; set; }
        public string Mabn { get; set; }
        public string Makhoa { get; set; }
        public string Magiuong { get; set; }
        public string Manv { get; set; }
        public string Maicd { get; set; }
        public string Tenicd { get; set; }
        public string Maicdp { get; set; }
        public string Tenicdp { get; set; }

        public DienBien()
        {

        }
        public DienBien(string iddb, string mabn, string maba, string makhoa, string magiuong, string manv, string maicd, string tenicd, string maiicdp, string tenicdp)
        {
            this.Iddienbien = iddb;
            this.Mabn = mabn;
            this.Maba = maba;
            this.Makhoa = makhoa;
            this.Magiuong = magiuong;
            this.Manv = manv;
            this.Maicd = maicd;
            this.Tenicd = tenicd;
            this.Maicdp = Maicdp;
            this.Tenicdp = tenicdp;
        }
    }
}