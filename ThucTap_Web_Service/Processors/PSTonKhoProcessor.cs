using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class PSTonKhoProcessor
    {
        public static string ThemPSTonKho(PSTonKho psTonKho)
        {
            return PSTonKhoRepository.AddPSTonKho(psTonKho);
        }

        public static List<PSTonKho> DanhMucPSTonKho()
        {
            return PSTonKhoRepository.ShowAllPSTonKho();
        }

        public static PSTonKho ThongTinPSTonKho(int id)
        {
            return PSTonKhoRepository.ShowPSTonKho(id);
        }

        public static string SuaPSTonKho(PSTonKho psTonKho)
        {
            return PSTonKhoRepository.UpdatePSTonKho(psTonKho);
        }

        public static string XoaPSTonKho(int id)
        {
            return PSTonKhoRepository.DeletePSTonKho(id);
        }
    }
}