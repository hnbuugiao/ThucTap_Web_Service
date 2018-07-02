using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Models;

namespace ThucTap_Web_Service.Repositories
{
    public class ToaThuocRepository

    {
        public static ThongBao tb = new ThongBao();
        //Lưu toa thuốc nhập vào thông tin PSthuoc (toa thuoc ) và danh sách pschitietthuoc
        public static string NhapToaThuoc(ToaThuoc toathuoc)
        {
            var toa = toathuoc.Toa;
            var chitietthuoc = toathuoc.Chitietthuoc;
            foreach (PSChiTietThuoc thuoc in chitietthuoc)
            {
                if (thuoc.Idpsthuoc != toa.Idpsthuoc)
                {
                    return "mã toa của chi tiết thuốc không trùng khớ với mã số toa tại thuốc: " +thuoc.Mahh;
                }
            }
            var luutoa=PSThuocRepository.AddPSThuoc(toa);
            if (luutoa == tb.add_successed)
            {
                foreach (PSChiTietThuoc thuoc in chitietthuoc)
                {
                    var luuctthuoc =PSChiTietThuocRepository.AddPSChiTietThuoc(thuoc);
                    
                }
            }

            return tb.add_failed;
        }

        public static void HuyToaThuoc(List<PSChiTietThuoc> chitietthuoc)
        {
            foreach (PSChiTietThuoc thuoc in chitietthuoc)
            {
               var huytoa= QuanLyTonKhoRepository.HuyXuatTam(thuoc);
            }
         
        }
    }
}