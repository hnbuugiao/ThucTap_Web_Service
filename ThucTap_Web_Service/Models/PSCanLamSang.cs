using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class PSCanLamSang
    {
        public int ID { get; set; }
        public string Mabn { get; set; }
        public string Maba { get; set; }
        public string Makhoa { get; set; }
        public string Macls { get; set; }

        public double Dongia { get; set; }

        public PSCanLamSang() { }
        public PSCanLamSang(int id,string mabn,string  maba,string mak,string macls,double dg)
        {
            this.ID = id;
            this.Mabn = mabn;
            this.Maba = maba;
            this.Makhoa = mak;
            this.Macls = macls;
            this.Dongia = dg;

        }
    }
}