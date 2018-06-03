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
    public class PSCanLamSangRepository
    {
        private static string connectstring = new ConnectString().GetConnectString();
       
        public static string AddPSCanLanSangToDB(PSCanLamSang cls)
        {
            try
            {
              
                string query = "INSERT INTO current.pscls(Iddienbien,mabn,maba,makhoa,macls,dongia) VALUES(@Iddienbien,@mabn,@maba,@makhoa,@macls,@dongia)";
                NpgsqlConnection conn = new NpgsqlConnection(connectstring);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value = cls.Iddienbien;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = cls.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = cls.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = cls.Makhoa;
                cmd.Parameters.Add("@macls", NpgsqlDbType.Varchar).Value = cls.Macls;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Numeric).Value = cls.Dongia;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thêm thành công";
            }
            catch(Exception e)
            {
                Console.WriteLine("loi them pscls: " + e.Message);
                return e.Message;
            }
            
        }

        public static string UpdatePSCanLanSang(PSCanLamSang cls)
        {
            try
            {
                string query = "UPDATE current.pscls SET Iddienbien=@Iddienbien,mabn=@mabn,maba=@maba,makhoa=@makhoa,macls=@macls,dongia=@dongia WHERE ID=@ID";
                NpgsqlConnection conn = new NpgsqlConnection(connectstring);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@ID", NpgsqlDbType.Integer).Value = cls.ID;
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value = cls.Iddienbien;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = cls.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = cls.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = cls.Makhoa;
                cmd.Parameters.Add("@macls", NpgsqlDbType.Varchar).Value = cls.Macls;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Numeric).Value = cls.Dongia;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Sửa thành công";
            }
            catch (Exception e)
            {
                Console.WriteLine("loi them pscls: " + e.Message);
                return e.Message;
            }

        }


        public static List<PSCanLamSang> ShowAllPSCanLamSangFromDB()
        {
            // Lấy connection

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.pscls";

            // Tạo List chứa dữ liệu
            List<PSCanLamSang> list = new List<PSCanLamSang>();

            //Tạo kết nối
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);


            // Lấy dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Thêm vào list
                    list.Add(new PSCanLamSang(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDouble(6)));
                }
                conn.Close();
                Console.WriteLine("Thành công: "+list.ToString());
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return list;
            }
        }

        public static PSCanLamSang ShowPSCanLamSangFromDB(int id)
        {
            // Lấy connection

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.pscls WHERE ID=@ID";

            // Tạo List chứa dữ liệu
            PSCanLamSang pscls = new PSCanLamSang();

            //Tạo kết nối
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);


            // Lấy dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@ID", NpgsqlDbType.Numeric).Value = id;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                
                    // Thêm vào list
                pscls= new PSCanLamSang(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDouble(6));
               
                conn.Close();
                Console.WriteLine("Thành công");
                return pscls;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return pscls;
            }
        }

        public static string XoaPSCLS(int macls)
        {
 

            // Câu truy vấn xoá bệnh nhân với Mã bệnh nhân
            var query = "DELETE FROM current.pscls WHERE ID =@ID";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@ID", NpgsqlDbType.Numeric).Value = macls;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Xóa Thành công");
                return "Xóa Thành công";
            }
            catch (Exception)
            {
                Console.WriteLine("Xóa Thất bại");
                return "Xóa Thất bại";

            }
        }
    }
}