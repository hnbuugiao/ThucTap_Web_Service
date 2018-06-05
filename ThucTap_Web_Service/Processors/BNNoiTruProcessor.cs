using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class BNNoiTruProcessor
    {
        public static string ThemBNNoiTru(BNNoiTru bnnoitru)
        {
            return BNNoiTruRepository.AddBNNoiTru(bnnoitru);
        }

        public static List<BNNoiTru> DanhMucBNNoiTru()
        {
            return BNNoiTruRepository.ShowAllBNNoiTru();
        }

        public static BNNoiTru ThongTinBNNoiTru(int id)
        {
            return BNNoiTruRepository.ShowBNNoiTru(id);
        }

        public static string SuaBNNoiTru(BNNoiTru bnnoitru)
        {
            return BNNoiTruRepository.UpdateBNNoiTru(bnnoitru);
        }

        public static string XoaBNNoiTru(int id)
        {
            return BNNoiTruRepository.DeleteBNNoiTru(id);
        }
    }
}