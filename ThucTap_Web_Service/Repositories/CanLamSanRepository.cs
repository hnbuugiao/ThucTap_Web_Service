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
    public class CanLamSanRepository
    {
        ConnectString connect = new ConnectString();
        public string GetConnectString()
        {
            return connect.connectionstring;
        }

        public static string AddCLSToDB(CanLamSan canlamsan)
        {
            //Câu lệnh SQL thêm vào Database
            string query = "INSERT INTO current.dmcls VALUES(@macls,@tencls,@dvt,@dongia)";

            //Get connectioin từ folder Conections
            CanLamSanRepository getstring = new CanLamSanRepository();
            string connectstring = getstring.GetConnectString();
            //Tạo kết nối tới PostgreSQL
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            //Try thêm dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@macls", NpgsqlDbType.Varchar).Value = canlamsan.macls;
                cmd.Parameters.Add("@tencls", NpgsqlDbType.Varchar).Value = canlamsan.tencls;
                cmd.Parameters.Add("@dvt", NpgsqlDbType.Varchar).Value = canlamsan.dvt;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Double).Value = canlamsan.dongia;
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

        public static List<CanLamSan> ShowAllCLSFromDB()
        {
            // Lấy connection
            CanLamSanRepository getstring = new CanLamSanRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.dmcls";

            // Tạo List chứa dữ liệu
            List<CanLamSan> list = new List<CanLamSan>();

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
                    list.Add(new CanLamSan(reader.GetString(0), reader.GetString(1), reader.GetString(2),reader.GetInt32(3)));
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

        public static List<CanLamSan> ShowCLSFromDB(String macls)
        {
            //Lấy connection
            CanLamSanRepository getstring = new CanLamSanRepository();
            string connectstring = getstring.GetConnectString();

            //Câu truy vấn dữ liệu với điều kiện Mã bệnh nhân
            var query = "SELECT * FROM current.dmcls WHERE macls = @macls";
            List<CanLamSan> list = new List<CanLamSan>();
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn); ;
                cmd.Parameters.Add("@macls", NpgsqlDbType.Varchar).Value = macls;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new CanLamSan(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));

                }
                conn.Close();
                Console.WriteLine("Thành công");
                return list;
            }
            catch (Exception)
            {
                Console.WriteLine("Thất bại");
                return list;
            }
        }

        public static bool SuaThongTinCLS(CanLamSan canlamsan)
        {
            CanLamSanRepository getstring = new CanLamSanRepository();
            string connectstring = getstring.GetConnectString();

            // Câu lệnh cập nhật bệnh nhân dựa theo mã bệnh nhân,cập nhật dữ liệu các trường còn lại
            String query = "UPDATE current.dmcls SET tencls=@tencls,dvt=@dvt,dongia=@dongia WHERE macls=@macls";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@tencls", NpgsqlDbType.Varchar).Value = canlamsan.tencls;
                cmd.Parameters.Add("@dvt", NpgsqlDbType.Varchar).Value = canlamsan.dvt;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Double).Value = canlamsan.dongia;
                cmd.Parameters.Add("@macls", NpgsqlDbType.Varchar).Value = canlamsan.macls;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Thành công");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Thất bại");
                return false;

            }
        }

        public static bool XoaCLS(string macls)
        {
            CanLamSanRepository getstring = new CanLamSanRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn xoá bệnh nhân với Mã bệnh nhân
            var query = "DELETE FROM current.dmcls WHERE macls =@macls";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@macls", NpgsqlDbType.Varchar).Value = macls;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Thành công");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Thất bại");
                return false;

            }
        }
        
    }
}