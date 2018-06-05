using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class BenhAnProcessor
    {
        public static string ThemBenhAn(BenhAn ba)
        {
            return BenhAnRepository.AddBenhAn(ba);
        }

        public static List<BenhAn> DanhMucBenhAn()
        {
            return BenhAnRepository.ShowAllBenhAn();
        }

        public static BenhAn ThongTinBenhAn(string id)
        {
            return BenhAnRepository.ShowBenhAn(id);
        }

        public static string SuaBenhAn(BenhAn ba)
        {
            return BenhAnRepository.UpdateBenhAn(ba);
        }

        public static string XoaBenhAn(string id)
        {
            return BenhAnRepository.DeleteBenhAn(id);
        }

    }
}