using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Connections;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Repositories;

namespace ThucTap_Web_Service.Repositories
{
    public class QuanLyTonKhoRepository
    {

        private static string connectstring = new ConnectString().GetConnectString();
        private static NpgsqlConnection conn = new NpgsqlConnection(connectstring);
        public static ThongBao tb = new ThongBao();
        public static string XuatTam(PSChiTietThuoc pschitietthuoc)
        {
            // return JsonConvert.SerializeObject(pschitietthuoc);


            try
            {
                DienBien dienbien = DienBienRepository.ShowDienBienFromDB(pschitietthuoc.Iddienbien);
                //kiểm tra diễn biến có tòn tại ko
                if (dienbien.Iddienbien == null)
                {
                    return "Mã diễn biên không tôn tại";
                }
                if (dienbien.Mabn != pschitietthuoc.Mabn)
                {

                }

                if (dienbien.Maba != pschitietthuoc.Maba)
                {

                }

                if (dienbien.Makhoa != pschitietthuoc.Makhoa)
                {

                }

                var mathuoc = pschitietthuoc.Mahh;
                var dongia = pschitietthuoc.Dongia;
                var soluong = pschitietthuoc.Soluong;
                var thanhtien = pschitietthuoc.Thanhtien;
                //kiem tra ma thuoc co ton tai trong pstonkho
                var thuoctonkho = PSTonKhoRepository.ShowPSTonKho(mathuoc); // lấy thông tin từ bảng pstonkho
                if (thuoctonkho.Mahh == null)
                {
                    return "Mã thuốc không tôn tại trong tồn kho";
                }




                if (dongia != thuoctonkho.Dongia)
                {
                    return "Sai đơn giá";
                }

                //kiem tra thanh tien
                var sotien = dongia * soluong;
                /* if (thanhtien != sotien)
                 {
                    // return sotien + "khác" + thanhtien + ": client và server tính khác nhau";
                 }*/

                //kiểm tra lại số thuốc trong pstonkho lần nữa
                PSTonKho pstonkho = PSTonKhoRepository.ShowPSTonKho(mathuoc);
                if (pstonkho.Xuattam + soluong <= pstonkho.Tondau)
                    pstonkho.Xuattam += soluong;
                //so thuoc cho phep ghi vào tao
                var tondau = pstonkho.Tondau -soluong;
                if (tondau < 0)
                {
                    return "không đủ thuốc";
                }
                else
                {
                    pstonkho.Tondau = tondau;
                }
                PSTonKhoRepository.UpdatePSTonKho(pstonkho);
                return JsonConvert.SerializeObject(PSTonKhoRepository.ShowPSTonKho(mathuoc));


            }
            catch (Exception e)
            {
                conn.Close();
                return e.Message;
            }
        }


            public static string HuyXuatTam(PSChiTietThuoc pschitietthuoc)
            {
                // return JsonConvert.SerializeObject(pschitietthuoc);


                try
                {
                    DienBien dienbien = DienBienRepository.ShowDienBienFromDB(pschitietthuoc.Iddienbien);
                    //kiểm tra diễn biến có tòn tại ko
                    if (dienbien.Iddienbien == null)
                    {
                        return "Mã diễn biên không tôn tại";
                    }
                    if (dienbien.Mabn != pschitietthuoc.Mabn)
                    {

                    }

                    if (dienbien.Maba != pschitietthuoc.Maba)
                    {

                    }

                    if (dienbien.Makhoa != pschitietthuoc.Makhoa)
                    {

                    }

                    var mathuoc = pschitietthuoc.Mahh;
                    var dongia = pschitietthuoc.Dongia;
                    var soluong = pschitietthuoc.Soluong;
                    var thanhtien = pschitietthuoc.Thanhtien;
                    //kiem tra ma thuoc co ton tai trong pstonkho
                    var thuoctonkho = PSTonKhoRepository.ShowPSTonKho(mathuoc); // lấy thông tin từ bảng pstonkho
                    if (thuoctonkho.Mahh == null)
                    {
                        return "Mã thuốc không tôn tại trong tồn kho";
                    }




                    if (dongia != thuoctonkho.Dongia)
                    {
                        return "Sai đơn giá";
                    }

                    //kiem tra thanh tien
                    var sotien = dongia * soluong;
                    /* if (thanhtien != sotien)
                     {
                        // return sotien + "khác" + thanhtien + ": client và server tính khác nhau";
                     }*/

                    //kiểm tra lại số thuốc trong pstonkho lần nữa
                    PSTonKho pstonkho = PSTonKhoRepository.ShowPSTonKho(mathuoc);
                    //if (pstonkho.Xuattam + soluong <= pstonkho.Tondau)
                    pstonkho.Xuattam -= soluong;
               
                    pstonkho.Tondau += soluong;
                    
                    PSTonKhoRepository.UpdatePSTonKho(pstonkho);
                    return JsonConvert.SerializeObject(PSTonKhoRepository.ShowPSTonKho(mathuoc));


                }
                catch (Exception e)
                {
                    conn.Close();
                    return e.Message;
                }
            }



        public static string PhatThuoc(PSChiTietThuoc pschitietthuoc)
        {
            // return JsonConvert.SerializeObject(pschitietthuoc);
            var mathuoc = pschitietthuoc.Mahh;
            var soluong = pschitietthuoc.Soluong;
            try
            {
                PSTonKho pstonkho = PSTonKhoRepository.ShowPSTonKho(mathuoc);
                var xuattam = pstonkho.Xuattam - soluong;
                if ( xuattam>=0)
                    pstonkho.Xuattam =xuattam;
                if(pstonkho.Xuattam>=pstonkho.Xuat+soluong)
                    pstonkho.Xuat =pstonkho.Xuat+soluong;
                pstonkho.Toncuoi = pstonkho.Tondau + pstonkho.Xuattam;
                
                PSTonKhoRepository.UpdatePSTonKho(pstonkho);
                return JsonConvert.SerializeObject(PSTonKhoRepository.ShowPSTonKho(mathuoc));

            }
            catch (Exception e)
            {
                conn.Close();
                return e.Message;
            }
        }
    }
}