using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using ThucTap_Web_Service.Models;
using ThucTap_Web_Service.Connections;
using System.Globalization;
using NpgsqlTypes;
using Newtonsoft.Json;


namespace ThucTap_Web_Service.Repositories
{
    public class NhanVienRepository
    {
        ConnectString connect = new ConnectString();
        public string GetConnectString()
        {
            return connect.connectionstring;
        }
        public static ThongBao tb = new ThongBao();
        public static string AddNhanVienToDB(NhanVien nhanvien)
        {

            //Câu lệnh SQL thêm vào Database
            string query = "INSERT INTO current.dmnhanvien VALUES(@manv,@hoten,@taikhoan,@matkhau)";

            //Get connectioin từ folder Conections
            NhanVienRepository getstring = new NhanVienRepository();
            string connectstring = getstring.GetConnectString();
            //Tạo kết nối tới PostgreSQL
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            //Try thêm dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@manv", NpgsqlDbType.Varchar).Value = nhanvien.manv;
                cmd.Parameters.Add("@hoten", NpgsqlDbType.Varchar).Value = nhanvien.hoten;
                cmd.Parameters.Add("@taikhoan", NpgsqlDbType.Varchar).Value = nhanvien.taikhoan;
                cmd.Parameters.Add("@matkhau", NpgsqlDbType.Varchar).Value = nhanvien.matkhau;
                cmd.ExecuteNonQuery();
                conn.Close();

                return tb.add_successed;
            }
            // Bắt trường hợp lỗi
            catch (Exception e)
            {
                return e.Message;

            }
        }

        public static List<NhanVien> ShowAllNhanVienFromDB()
        {
            // Lấy connection
            BenhNhanRepository getstring = new BenhNhanRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.dmnhanvien";

            // Tạo List chứa dữ liệu
            List<NhanVien> list = new List<NhanVien>();

            //Tạo kết nối
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);


            // Lấy dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn); ;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new NhanVien(reader.GetString(0), reader.GetString(1), reader.GetString(2),reader.GetString(3)));
                }
                conn.Close();
                Console.WriteLine("Thành công");
                return list;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                return list;
            }
        }

        public static bool ShowNhanVienFromDB(String taikhoan,String matkhau)
        {
            //Lấy connection
            NhanVienRepository getstring = new NhanVienRepository();
            string connectstring = getstring.GetConnectString();

            //Câu truy vấn dữ liệu với điều kiện Mã bệnh nhân
            var query = "SELECT * FROM current.dmnhanvien WHERE taikhoan = @taikhoan AND matkhau = @matkhau";
            List<NhanVien> list = new List<NhanVien>();
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn); ;
                cmd.Parameters.Add("@taikhoan", NpgsqlDbType.Varchar).Value = taikhoan;
                cmd.Parameters.Add("@matkhau", NpgsqlDbType.Varchar).Value = matkhau;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new NhanVien(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));

                }
                conn.Close();
                Console.WriteLine("Thành công");
                return list.Count>0?true:false;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return list.Count > 0 ? true : false;
            }
        }

        public static string SuaThongTinNhanVien(NhanVien nhanvien)
        {
            NhanVienRepository getstring = new NhanVienRepository();
            string connectstring = getstring.GetConnectString();


            // Câu lệnh cập nhật bệnh nhân dựa theo mã bệnh nhân,cập nhật dữ liệu các trường còn lại
            String query = "UPDATE current.dmnhanvien SET hoten=@hoten,matkhau=@hoten WHERE manv=@manv";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@hoten", NpgsqlDbType.Varchar).Value = nhanvien.hoten;
                cmd.Parameters.Add("@hoten", NpgsqlDbType.Varchar).Value = nhanvien.hoten;
                cmd.Parameters.Add("@manv", NpgsqlDbType.Varchar).Value = nhanvien.manv;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Thành công");
                return tb.update_successed;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return e.Message;

            }
        }

        public static string XoaNhanVien(string manv)
        {
            BenhNhanRepository getstring = new BenhNhanRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn xoá bệnh nhân với Mã bệnh nhân
            var query = "DELETE FROM current.dmnhanvien WHERE manv =@manv";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@manv", NpgsqlDbType.Varchar).Value = manv;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Thành công");
                return "Xóa thành công";
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return "Xóa thất bại";

            }
        }

    }
}