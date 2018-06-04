using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Connections;
using ThucTap_Web_Service.Models;

namespace ThucTap_Web_Service.Repositories
{
    public class DienBienRepository
    {
        private static string connectstring = new ConnectString().GetConnectString();

        public static string AddDienBienToDB(DienBien dienbien)
        {
            //Cấu trúc connection
            //var connectionstring = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456;Database=svthuctap;";


            //Câu lệnh SQL thêm vào Database
            string query = "INSERT INTO current.dienbien VALUES(@Iddienbien,@mabn,@maba,@makhoa,@magiuong,@manv,@maicd,@tenicd,@maicdp,@tenicdp)";

          
            //Tạo kết nối tới PostgreSQL
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            //Try thêm dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value = dienbien.Iddienbien;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = dienbien.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = dienbien.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = dienbien.Makhoa;
                cmd.Parameters.Add("@magiuong", NpgsqlDbType.Varchar).Value = dienbien.Magiuong;
                cmd.Parameters.Add("@manv", NpgsqlDbType.Varchar).Value = dienbien.Manv;
                cmd.Parameters.Add("@maicd", NpgsqlDbType.Varchar).Value = dienbien.Maicd;
                cmd.Parameters.Add("@tenicd", NpgsqlDbType.Varchar).Value = dienbien.Tenicd;
                cmd.Parameters.Add("@maicdp", NpgsqlDbType.Varchar).Value = dienbien.Maicdp;
                cmd.Parameters.Add("@Tenicdp", NpgsqlDbType.Varchar).Value = dienbien.Tenicdp;

                cmd.ExecuteNonQuery();
                conn.Close();

                return "Thêm thành công!";
            }
            // Bắt trường hợp lỗi
            catch (Exception e)
            {
                conn.Close();
                return e.Message;

            }
        }

        public static List<DienBien> ShowAllDienBienFromDB()
        {
            // Lấy connection

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.dienbien";

            // Tạo List chứa dữ liệu
            List<DienBien> list = new List<DienBien>();

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
                    // Thêm vào list
                 list.Add(new DienBien(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9)));
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

        public static DienBien ShowDienBienFromDB(String madb)
        { 
            //Lấy connection

            //Câu truy vấn dữ liệu khi biết id diễn biến
            var query = "SELECT * FROM current.dienbien WHERE Iddienbien=@Iddienbien";
     
            List<DienBien> list = new List<DienBien>();
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);
            DienBien db = new DienBien();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn); ;
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value=madb;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                db = new DienBien(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                conn.Close();
                Console.WriteLine("Thành công");
                return db;
            }
            catch (Exception)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return db;
            }
        }

        public static string SuaThongTinDienBien(DienBien dienbien)
        {


            // Câu lệnh cập nhật bệnh nhân dựa theo id diễn biến,cập nhật dữ liệu các trường còn lại
           
            String query = "UPDATE current.dienbien SET mabn=@mabn,maba=@maba,makhoa=@makhoa,magiuong=@magiuong,manv=@manv,maicd=@maicd,tenicd=@tenicd,maicdp=@maicdp,tenicdp=@tenicdp WHERE Iddienbien=@Iddienbien";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value = dienbien.Iddienbien;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = dienbien.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = dienbien.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = dienbien.Makhoa;
                cmd.Parameters.Add("@magiuong", NpgsqlDbType.Varchar).Value = dienbien.Magiuong;
                cmd.Parameters.Add("@manv", NpgsqlDbType.Varchar).Value = dienbien.Manv;
                cmd.Parameters.Add("@maicd", NpgsqlDbType.Varchar).Value = dienbien.Maicd;
                cmd.Parameters.Add("@tenicd", NpgsqlDbType.Varchar).Value = dienbien.Tenicd;
                cmd.Parameters.Add("@maicdp", NpgsqlDbType.Varchar).Value = dienbien.Maicdp;
                cmd.Parameters.Add("@Tenicdp", NpgsqlDbType.Varchar).Value = dienbien.Tenicdp;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Sửa Thành công");
                return "Sửa thành công";
            }
            catch (Exception)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return "Sửa Thất Bại";

            }
        }

        public static string XoaDienBien(string madb)
        {


            // Câu truy vấn xoá diễn biến
            var query = "DELETE FROM current.dienbien WHERE Iddienbien =@Iddienbien";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value = madb;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Thành công");
                return "Xóa thành công";
            }
            catch (Exception)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return "Xóa Thất Bại";

            }
        }

        
    }
}