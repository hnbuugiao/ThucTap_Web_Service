using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class CanLamSan
    {
        public string macls { get; set; }
        public string tencls { get; set; }
        public string dvt { get; set; }
        public int dongia { get; set; }

        public CanLamSan()
        {

        }

        public CanLamSan(string macls, string tencls, string dvt, int dongia)
        {
            this.macls = macls;
            this.tencls = tencls;
            this.dvt = dvt;
            this.dongia = dongia;
        }
    }
}