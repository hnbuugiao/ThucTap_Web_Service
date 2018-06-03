using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class PSThuocProcessor
    {
        public static string ThemPSThuoc(PSThuoc psthuoc)
        {
            return PSThuocRepository.AddPSThuoc(psthuoc);
        }

        public static List<PSThuoc> DanhMucPSThuoc()
        {
            return PSThuocRepository.ShowAllPSThuoc();
        }

        public static PSThuoc ThongTinPSThuoc(string id)
        {
            return PSThuocRepository.ShowPSThuoc(id);
        }

        public static string SuaPSThuoc(PSThuoc psthuoc)
        {
            return PSThuocRepository.UpdatePSThuoc(psthuoc);
        }

        public static string XoaPSThuoc(string id)
        {
            return PSThuocRepository.DeletePSThuoc(id);
        }
    }
}