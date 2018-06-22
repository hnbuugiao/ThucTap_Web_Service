using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class NhanVienProcessor
    {
        public static string AddNhanVien(NhanVien nhanvien)
        {
            return NhanVienRepository.AddNhanVienToDB(nhanvien);
        }

        public static List<NhanVien> ShowAllNhanVien()
        {
            return NhanVienRepository.ShowAllNhanVienFromDB();
        }

        public static bool ShowNhanVien(string manv,string matkhau)
        {
            return NhanVienRepository.ShowNhanVienFromDB(manv,matkhau);
        }
 
        public static string SuaThongTinNhanVien(NhanVien nhanvien)
        {
            return NhanVienRepository.SuaThongTinNhanVien(nhanvien);
        }

        public static string XoaNhanVien(string manv)
        {
            return NhanVienRepository.XoaNhanVien(manv);
        }
    }
}