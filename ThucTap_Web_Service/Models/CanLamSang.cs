using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class CanLamSang
    {
        public string macls { get; set; }
        public string tencls { get; set; }
        public string dvt { get; set; }
        public double dongia { get; set; }

        public CanLamSang()
        {

        }

        public CanLamSang(string macls, string tencls, string dvt, double dongia)
        {
            this.macls = macls;
            this.tencls = tencls;
            this.dvt = dvt;
            this.dongia = dongia;
        }
    }
}