using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;


namespace ThucTap_Web_Service.Processors
{
    public class ThuocProcessor
    {
        public static string AddThuoc(Thuoc thuoc)
        {
            return ThuocRepository.AddThuocToDB(thuoc);
        }

        public static List<Thuoc> ShowAllThuoc()
        {
            return ThuocRepository.ShowAllThuocFromDB();
        }

        public static Thuoc ShowThuoc(string mahh)
        {
            return ThuocRepository.ShowThuocFromDB(mahh);
        }

        public static bool SuaThongTinThuoc(Thuoc thuoc)
        {
            return ThuocRepository.SuaThongTinThuoc(thuoc);
        }

        public static bool XoaThuoc(string mahh)
        {
            return ThuocRepository.XoaThuoc(mahh);
        }


    }
}