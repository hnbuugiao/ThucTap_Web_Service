using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Processors
{
    public class PSChiTietThuocProcessor
    {
        public static string ThemPSChiTietThuoc(PSChiTietThuoc pschitietthuoc)
        {
            return PSChiTietThuocRepository.AddPSChiTietThuoc(pschitietthuoc);
        }

        public static List<PSChiTietThuoc> DanhMucPSChiTietThuoc()
        {
            return PSChiTietThuocRepository.ShowAllPSChiTietThuoc();
        }

        public static PSChiTietThuoc ThongTinPSChiTietThuoc(int id)
        {
            return PSChiTietThuocRepository.ShowPSChiTietThuoc(id);
        }

        public static string SuaPSChiTietThuoc(PSChiTietThuoc pschitietthuoc)
        {
            return PSChiTietThuocRepository.UpdatePSChiTietThuoc(pschitietthuoc);
        }

        public static string XoaPSChiTietThuoc(int id)
        {
            return PSChiTietThuocRepository.DeletePSChiTietThuoc(id);
        }
    }
}