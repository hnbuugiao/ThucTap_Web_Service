using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class PSTonKho
    {

        public string Mahh { get; set; }
        public double Dongia { get; set; }
        public long Xuattam { get; set; }
        public long Tondau { get; set; }
        public long Nhap { get; set; }
        public long Xuat { get; set; }
        public long Toncuoi { get; set; }
        public PSTonKho() { }
        public PSTonKho(string mahh, double dg, long sl, long tondau, long nhap, long xuat, long toncuoi)
        {
 
            Mahh = mahh;
            Dongia = dg;
            Xuattam = sl;
            Tondau = tondau;
            Nhap = nhap;
            Xuat = xuat;
            Toncuoi = toncuoi;
        }

    }
}