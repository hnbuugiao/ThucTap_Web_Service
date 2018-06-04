using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class PSTonKho
    {
        public int ID { get; set; }
        public string Mahh { get; set; }
        public double Dongia { get; set; }
        public long Soluong { get; set; }
        public long Tondau { get; set; }
        public long Nhap { get; set; }
        public long Xuat { get; set; }
        public long Toncuoi { get; set; }
        public PSTonKho() { }
        public PSTonKho(int id, string mahh, double dg, long sl, long tondau, long nhap, long xuat, long toncuoi)
        {
            ID = id;
            Mahh = mahh;
            Dongia = dg;
            Soluong = sl;
            Tondau = tondau;
            Nhap = nhap;
            Xuat = xuat;
            Toncuoi = toncuoi;
        }

    }
}