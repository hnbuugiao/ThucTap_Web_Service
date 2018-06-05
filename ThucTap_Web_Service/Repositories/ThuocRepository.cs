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
        ConnectString connect = new ConnectString();
        public string GetConnectString()
        {
            return connect.connectionstring;
        }

        public static string AddThuocToDB(Thuoc thuoc)
        {
            //Câu lệnh SQL thêm vào Database
            string query = "INSERT INTO current.dmthuoc VALUES(@mahh,@tenhh,@dtv)";

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
                cmd.Parameters.Add("@dtv", NpgsqlDbType.Varchar).Value = thuoc.dvt;
                cmd.ExecuteNonQuery();
                conn.Close();

                return "Thêm thành công!";
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
                    list.Add(new Thuoc(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                }
                conn.Close();
                Console.WriteLine("Thành công");
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return list;
            }
        }

        public static List<Thuoc> ShowThuocFromDB(String mahh)
        {
            //Lấy connection
            BenhNhanRepository getstring = new BenhNhanRepository();
            string connectstring = getstring.GetConnectString();

            //Câu truy vấn dữ liệu với điều kiện Mã bệnh nhân
            var query = "SELECT * FROM current.dmthuoc WHERE mahh = @mahh";

            List<Thuoc> list = new List<Thuoc>();
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn); ;
                //cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = mabn;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = mahh;
                while (reader.Read())
                {
   
                    list.Add(new Thuoc(reader.GetString(0), reader.GetString(1), reader.GetString(2)));

                }
                conn.Close();
                Console.WriteLine("Thành công");
                return list;
            }
            catch (Exception)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return list;
            }
        }

        public static bool SuaThongTinThuoc(Thuoc thuoc)
        {
            ThuocRepository getstring = new ThuocRepository();
            string connectstring = getstring.GetConnectString();

            // Câu lệnh cập nhật bệnh nhân dựa theo mã bệnh nhân,cập nhật dữ liệu các trường còn lại
            String query = "UPDATE current.dmthuoc SET tenhh = @tenhh, dvt = @dvt WHERE mahh = @mahh";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@tenhh", NpgsqlDbType.Varchar).Value = thuoc.tenhh;
                cmd.Parameters.Add("@dvt", NpgsqlDbType.Varchar).Value = thuoc.dvt;
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = thuoc.mahh;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Thành công");
                return true;
            }
            catch (Exception)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return false;

            }
        }

        public static bool XoaThuoc(string mahh)
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
                return true;
            }
            catch (Exception)
            {
                conn.Close();
                Console.WriteLine("Thất bại");
                return false;

            }
        }
    }
}