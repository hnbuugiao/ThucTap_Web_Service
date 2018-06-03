using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class PSCanLamSangProcessor
    {
        public static string AddPSCLS(PSCanLamSang canlamsan)
        {
            return PSCanLamSangRepository.AddPSCanLanSangToDB(canlamsan);
        }

        public static List<PSCanLamSang> ShowAllPSCLS()
        {
            return PSCanLamSangRepository.ShowAllPSCanLamSangFromDB();
        }

     public static PSCanLamSang ShowPSCLS(int id)
        {
            return PSCanLamSangRepository.ShowPSCanLamSangFromDB(id);
        }

        public static string SuaThongTinPSCLS(PSCanLamSang canlamsan)
        {
            return PSCanLamSangRepository.UpdatePSCanLanSang(canlamsan);
        }

        public static string XoaPSCLS(int macls)
        {
            return PSCanLamSangRepository.XoaPSCLS(macls);
        }
    }
}