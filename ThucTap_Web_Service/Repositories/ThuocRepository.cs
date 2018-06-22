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
    public class ThuocRepository
    {
        private static string connectstring = new ConnectString().GetConnectString();
        private static NpgsqlConnection conn = new NpgsqlConnection(connectstring);
        public static ThongBao tb = new ThongBao();
        ConnectString connect = new ConnectString();
        public string GetConnectString()
        {
            return connect.connectionstring;
        }

        public static string AddThuocToDB(Thuoc thuoc)
        {
            //Câu lệnh SQL thêm vào Database
            string query = "INSERT INTO current.dmthuoc VALUES(@mahh,@tenhh,@dtv,@dongia)";

            //Get connectioin từ folder Conections
            ThuocRepository getstring = new ThuocRepository();
            string connectstring = getstring.GetConnectString();
            //Tạo kết nối tới PostgreSQL
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            //Try thêm dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = thuoc.mahh;
                cmd.Parameters.Add("@tenhh", NpgsqlDbType.Varchar).Value = thuoc.tenhh;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Double).Value = thuoc.dongia;
                cmd.Parameters.Add("@dtv", NpgsqlDbType.Varchar).Value = thuoc.dvt;
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

        public static List<Thuoc> ShowAllThuocFromDB()
        {
            // Lấy connection
            ThuocRepository getstring = new ThuocRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.dmthuoc";

            // Tạo List chứa dữ liệu
            List<Thuoc> list = new List<Thuoc>();

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
                    list.Add(new Thuoc(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3)));
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

        public static Thuoc ShowThuocFromDB(String mahh)
        {
            // Lấy connection
            ThuocRepository getstring = new ThuocRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.dmthuoc WHERE mahh=@mahh";

            // Tạo List chứa dữ liệu
            Thuoc list = new Thuoc();

            //Tạo kết nối
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);


            // Lấy dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = mahh;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Thêm vào list
                    list = new Thuoc(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
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

        public static string SuaThongTinThuoc(Thuoc thuoc)
        {
            ThuocRepository getstring = new ThuocRepository();
            string connectstring = getstring.GetConnectString();

            // Câu lệnh cập nhật bệnh nhân dựa theo mã bệnh nhân,cập nhật dữ liệu các trường còn lại
            String query = "UPDATE current.dmthuoc SET tenhh = @tenhh, dvt = @dvt,dongia=@dongia WHERE mahh = @mahh";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@tenhh", NpgsqlDbType.Varchar).Value = thuoc.tenhh;
                cmd.Parameters.Add("@dvt", NpgsqlDbType.Varchar).Value = thuoc.dvt;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Double).Value = thuoc.dongia;
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = thuoc.mahh;
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

        public static string XoaThuoc(string mahh)
        {
            ThuocRepository getstring = new ThuocRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn xoá bệnh nhân với Mã bệnh nhân
            var query = "DELETE FROM current.dmthuoc WHERE mahh =@mahh";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = mahh;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Thành công");
                return "Xóa thành công";
            }
            catch (Exception)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return "Xóa thất bại";

            }
        }

        public static Thuoc TimTheoMaThuoc(String mahh)
        {
            // Lấy connection
            ThuocRepository getstring = new ThuocRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT pstonkho.mahh,tenhh,dvt,pstonkho.dongia FROM current.pstonkho JOIN current.dmthuoc ON dmthuoc.Mahh = pstonkho.Mahh WHERE pstonkho.mahh = @mahh";

            // Tạo List chứa dữ liệu
            Thuoc list = new Thuoc();

            //Tạo kết nối
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);


            // Lấy dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = mahh;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Thêm vào list
                    list = new Thuoc(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
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


        public static Thuoc TimTheoTenThuoc(String tenhh)
        {
            // Lấy connection
            ThuocRepository getstring = new ThuocRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT pstonkho.mahh,tenhh,dvt,pstonkho.dongia FROM current.pstonkho JOIN current.dmthuoc ON dmthuoc.Mahh = pstonkho.Mahh WHERE tenhh = @tenhh";

            // Tạo List chứa dữ liệu
            Thuoc list = new Thuoc();

            //Tạo kết nối
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);


            // Lấy dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@tenhh", NpgsqlDbType.Varchar).Value = tenhh;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Thêm vào list
                    list = new Thuoc(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
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
    }
}