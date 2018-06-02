using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class CanLamSanProcessor
    {
        public static string AddCLS(CanLamSan canlamsan)
        {
            return CanLamSanRepository.AddCLSToDB(canlamsan);
        }

        public static List<CanLamSan> ShowAllCLS()
        {
            return CanLamSanRepository.ShowAllCLSFromDB();
        }

        public static List<CanLamSan> ShowCLS(string macls)
        {
            return CanLamSanRepository.ShowCLSFromDB(macls);
        }

        public static bool SuaThongTinCLS(CanLamSan canlamsan)
        {
            return CanLamSanRepository.SuaThongTinCLS(canlamsan);
        }

        public static bool XoaCLS(string macls)
        {
            return CanLamSanRepository.XoaCLS(macls);
        }
    }
}