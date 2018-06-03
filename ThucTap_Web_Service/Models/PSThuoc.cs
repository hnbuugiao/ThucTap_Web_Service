using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class PSThuoc
    {
        public string Idpsthuoc { set; get; }
        public string Iddienbien { set; get; }
        public string Mabn { set; get; }
        public string Maba { set; get; }
        public string Makhoa { set; get; }
        public string Thanhtien { set; get; }

        public PSThuoc() { }
        public PSThuoc(string idps,string iddb,string mabn,string maba,string makhoa,string tt) {
            Idpsthuoc = idps;
            Iddienbien = iddb;
            Mabn = mabn;
            Maba = maba;
            Makhoa = makhoa;
            Thanhtien = tt;
        }
    }
}