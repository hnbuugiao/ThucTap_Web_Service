using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class Thuoc
    {
        public string mahh { get; set; }
        public string tenhh { get; set; }
        
        public string dvt { get; set; }
        public double dongia { get; set; }
        public Thuoc()
        {

        }

        public Thuoc(string mahh, string tenhh, string dvt, double dongia)
        {
            this.mahh = mahh;
            this.tenhh = tenhh;
            this.dongia = dongia;
            this.dvt = dvt;
        }
    }
}