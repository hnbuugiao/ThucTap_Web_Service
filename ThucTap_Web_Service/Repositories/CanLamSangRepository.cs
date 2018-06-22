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
    public class CanLamSangRepository
    {
        ConnectString connect = new ConnectString();
        public string GetConnectString()
        {
            return connect.connectionstring;
        }
        public static ThongBao tb = new ThongBao();
        public static string AddCLSToDB(CanLamSang canlamsan)
        {
            //Câu lệnh SQL thêm vào Database
            string query = "INSERT INTO current.dmcls VALUES(@macls,@tencls,@dvt,@dongia)";

            //Get connectioin từ folder Conections
            CanLamSangRepository getstring = new CanLamSangRepository();
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

                return tb.add_successed;
            }
            // Bắt trường hợp lỗi
            catch (Exception e)
            {
                return e.Message;

            }
        }

        public static List<CanLamSang> ShowAllCLSFromDB()
        {
            // Lấy connection
            CanLamSangRepository getstring = new CanLamSangRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.dmcls";

            // Tạo List chứa dữ liệu
            List<CanLamSang> list = new List<CanLamSang>();

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
                    list.Add(new CanLamSang(reader.GetString(0), reader.GetString(1), reader.GetString(2),reader.GetInt32(3)));
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

        public static CanLamSang ShowCLSFromDB(String macls)
        {
            //Lấy connection
            CanLamSangRepository getstring = new CanLamSangRepository();
            string connectstring = getstring.GetConnectString();
            Console.WriteLine("connect to: " + connectstring);
            //Câu truy vấn dữ liệu với điều kiện Mã CLS
            var query = "SELECT * FROM current.dmcls WHERE macls = @macls";
            CanLamSang list = new CanLamSang();
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn); ;
                cmd.Parameters.Add("@macls", NpgsqlDbType.Varchar).Value = macls;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    list = new CanLamSang(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                }
                
                conn.Close();
                Console.WriteLine("cls " + list.macls);
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("loi lay cls: "+e.Message);
                return list;
            }
        }

        public static CanLamSang ShowCLSFromDB2(string macls)
        {
            // Lấy connection
            CanLamSangRepository getstring = new CanLamSangRepository();
            string connectstring = getstring.GetConnectString();
            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.dmcls WHERE macls=@macls";

            // Tạo List chứa dữ liệu
            CanLamSang pscls = new CanLamSang();

            //Tạo kết nối
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);


            // Lấy dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@macls", NpgsqlDbType.Numeric).Value = macls;
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pscls = new CanLamSang(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                }
                conn.Close();
                Console.WriteLine("Thành công");
                return pscls;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                return pscls;
            }
        }

        public static string SuaThongTinCLS(CanLamSang canlamsan)
        {
            CanLamSangRepository getstring = new CanLamSangRepository();
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
                return tb.update_successed;
            }
            catch (Exception e)
            {
                Console.WriteLine("Thất bại");
                return e.Message;

            }
        }

        public static string XoaCLS(string macls)
        {
            CanLamSangRepository getstring = new CanLamSangRepository();
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
                return "xóa thành công";
            }
            catch (Exception)
            {
                Console.WriteLine("Thất bại");
                return "xóa thất bại";

            }
        }
        
    }
}