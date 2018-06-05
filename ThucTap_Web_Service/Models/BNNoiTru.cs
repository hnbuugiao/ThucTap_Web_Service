using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class BNNoiTru
    {
        public int ID { get; set; }
        public string Mabn { get; set; }
        public string Maba { get; set; }
        public string Makhoa { get; set; }
        public string Maicd { get; set; }
        public string Tenicd { get; set; }
        public string Maicdp { get; set; }
        public string Tenicdp { get; set; }

        public BNNoiTru() { }
        public BNNoiTru(int id, string mabn, string maba, string makh, string maicd, string tenicd, string maicdp, string tenicdp)
        {
            ID = id;
            Mabn = mabn;
            Maba = maba;
            Makhoa = makh;
            Maicd = maicd;
            Tenicd = tenicd;
            Maicdp = maicdp;
            Tenicdp = tenicdp;
        }
    }
}