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
    public class PSChiTietThuocRepository
    {
        private static string connectstring = new ConnectString().GetConnectString();
        private static NpgsqlConnection conn = new NpgsqlConnection(connectstring);

        public static string AddPSChiTietThuoc(PSChiTietThuoc pschitietthuoc)
        {
            string query = "INSERT INTO current.pschitietthuoc(Idpsthuoc,Iddienbien,mabn,maba,makhoa,mahh,dongia,soluong,thanhtien) VALUES(@Idpsthuoc,@Iddienbien,@mabn,@maba,@makhoa,@mahh,@dongia,@soluong,@thanhtien)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.Parameters.Add("@Idpsthuoc", NpgsqlDbType.Varchar).Value = pschitietthuoc.Idpsthuoc;
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value = pschitietthuoc.Iddienbien;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = pschitietthuoc.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = pschitietthuoc.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = pschitietthuoc.Makhoa;
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = pschitietthuoc.Mahh;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Numeric).Value = pschitietthuoc.Dongia;
                cmd.Parameters.Add("@soluong", NpgsqlDbType.Numeric).Value = pschitietthuoc.Soluong;
                cmd.Parameters.Add("@thanhtien", NpgsqlDbType.Numeric).Value = pschitietthuoc.Thanhtien;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thêm thành công";
            }
            catch (Exception e)
            {
                conn.Close();
                return e.Message;
            }
        }

        public static string UpdatePSChiTietThuoc(PSChiTietThuoc pschitietthuoc)
        {
            string query = "UPDATE current.pschitietthuoc SET Idpsthuoc=@Idpsthuoc,Iddienbien=@Iddienbien,mabn=@mabn,maba=@maba,makhoa=@makhoa,mahh=@mahh,dongia=@dongia,soluong=@soluong,thanhtien=@thanhtien WHERE ID=@ID";

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@ID", NpgsqlDbType.Integer).Value = pschitietthuoc.ID;
                cmd.Parameters.Add("@Idpsthuoc", NpgsqlDbType.Varchar).Value = pschitietthuoc.Idpsthuoc;
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value = pschitietthuoc.Iddienbien;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = pschitietthuoc.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = pschitietthuoc.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = pschitietthuoc.Makhoa;
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = pschitietthuoc.Mahh;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Numeric).Value = pschitietthuoc.Dongia;
                cmd.Parameters.Add("@soluong", NpgsqlDbType.Numeric).Value = pschitietthuoc.Soluong;
                cmd.Parameters.Add("@thanhtien", NpgsqlDbType.Numeric).Value = pschitietthuoc.Thanhtien;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Sửa thành công";
            }
            catch (Exception e)
            {
                conn.Close();
                return e.Message;
            }
        }

        public static List<PSChiTietThuoc> ShowAllPSChiTietThuoc()
        {
            List<PSChiTietThuoc> listpschitietthuoc = new List<PSChiTietThuoc>();
            string query = "SELECT * FROM current.pschitietthuoc";

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listpschitietthuoc.Add(new PSChiTietThuoc(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),reader.GetString(6),reader.GetDouble(7),reader.GetInt64(8) ,reader.GetDouble(9)));
                }
                conn.Close();


            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return listpschitietthuoc;

        }

        public static PSChiTietThuoc ShowPSChiTietThuoc(int id)
        {
            PSChiTietThuoc pschitietthuoc = new PSChiTietThuoc();
            string query = "SELECT * FROM current.pschitietthuoc WHERE ID=@ID";

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@ID", NpgsqlDbType.Integer).Value = id;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pschitietthuoc = new PSChiTietThuoc(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDouble(7), reader.GetInt64(8), reader.GetDouble(9));
                }
                conn.Close();


            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return pschitietthuoc;

        }

        public static string DeletePSChiTietThuoc(int id)
        {
            string query = "DELETE FROM current.pschitietthuoc WHERE ID=@ID";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@ID", NpgsqlDbType.Integer).Value = id;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Xóa thành công";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}