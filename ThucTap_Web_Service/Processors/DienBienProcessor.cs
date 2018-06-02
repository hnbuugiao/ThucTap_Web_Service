using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class DienBienProcessor
    {
        public static string AddDienBien(DienBien dienbien)
        {
            return DienBienRepository.AddDienBienToDB(dienbien);
        }

        public static List<DienBien> ShowAllDienBien()
        {
            return DienBienRepository.ShowAllDienBienFromDB();
        }

        public static DienBien ShowDienBien(string madb)
        {
            return DienBienRepository.ShowDienBienFromDB(madb);
        }

        public static string SuaThongTinDienBien(DienBien dienbien)
        {
            return DienBienRepository.SuaThongTinDienBien(dienbien);
        }

        public static string XoaDienBien(string madb)
        {
            return DienBienRepository.XoaDienBien(madb);
        }

      
    }
}