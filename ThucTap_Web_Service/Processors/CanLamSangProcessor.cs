using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class CanLamSangProcessor
    {
        public static string AddCLS(CanLamSang canlamsan)
        {
            return CanLamSangRepository.AddCLSToDB(canlamsan);
        }

        public static List<CanLamSang> ShowAllCLS()
        {
            return CanLamSangRepository.ShowAllCLSFromDB();
        }

        public static CanLamSang ShowCLS(string macls)
        {
            return CanLamSangRepository.ShowCLSFromDB(macls);
        }

        public static string SuaThongTinCLS(CanLamSang canlamsan)
        {
            return CanLamSangRepository.SuaThongTinCLS(canlamsan);
        }

        public static string XoaCLS(string macls)
        {
            return CanLamSangRepository.XoaCLS(macls);
        }
    }
}