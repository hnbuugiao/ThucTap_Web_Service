using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class BenhAn
    {
        public string Maba { get; set; }
        public string Mabn { get; set; }
        public string Ngaylap { get; set;}

        public BenhAn() { }
        public BenhAn(string maba,string mabn,string ngaylap)
        {
            Maba = maba;
            Mabn = mabn;
            Ngaylap = ngaylap;
        }
    }
}