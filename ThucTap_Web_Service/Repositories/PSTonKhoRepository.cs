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
    public class PSTonKhoRepository
    {
        private static string connectstring = new ConnectString().GetConnectString();
        private static NpgsqlConnection conn = new NpgsqlConnection(connectstring);
        public static ThongBao tb = new ThongBao();
        public static string AddPSTonKho(PSTonKho pstonkho)
        {
            string query = "INSERT INTO current.pstonkho(mahh,dongia,xuattam,tondau,nhap,xuat,toncuoi) VALUES(@mahh,@dongia,@xuattam,@tondau,@nhap,@xuat,@toncuoi)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value =pstonkho.Mahh;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Numeric).Value = pstonkho.Dongia;
                cmd.Parameters.Add("@xuattam", NpgsqlDbType.Numeric).Value = pstonkho.Xuattam;        
                cmd.Parameters.Add("@tondau", NpgsqlDbType.Numeric).Value = pstonkho.Tondau;
                cmd.Parameters.Add("@nhap", NpgsqlDbType.Numeric).Value = pstonkho.Nhap;
                cmd.Parameters.Add("@xuat", NpgsqlDbType.Numeric).Value = pstonkho.Xuat;
                cmd.Parameters.Add("@toncuoi", NpgsqlDbType.Numeric).Value = pstonkho.Toncuoi;
                cmd.ExecuteNonQuery();
                conn.Close();
                return tb.add_successed;
            }
            catch(Exception e)
            {
                conn.Close();
                return e.Message;
            }
        }

        public static string UpdatePSTonKho(PSTonKho pstonkho)
        {
            string query = "UPDATE current.pstonkho SET dongia=@dongia,xuattam=@xuattam,tondau=@tondau,nhap=@nhap,xuat=@xuat,toncuoi=@toncuoi WHERE mahh=@mahh";
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                //cmd.Parameters.Add("@ID", NpgsqlDbType.Integer).Value = pstonkho.ID;
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = pstonkho.Mahh;
                cmd.Parameters.Add("@dongia", NpgsqlDbType.Numeric).Value = pstonkho.Dongia;
                cmd.Parameters.Add("@xuattam", NpgsqlDbType.Numeric).Value = pstonkho.Xuattam;
                cmd.Parameters.Add("@tondau", NpgsqlDbType.Numeric).Value = pstonkho.Tondau;
                cmd.Parameters.Add("@nhap", NpgsqlDbType.Numeric).Value = pstonkho.Nhap;
                cmd.Parameters.Add("@xuat", NpgsqlDbType.Numeric).Value = pstonkho.Xuat;
                cmd.Parameters.Add("@toncuoi", NpgsqlDbType.Numeric).Value = pstonkho.Toncuoi;
                cmd.ExecuteNonQuery();
                conn.Close();
                return tb.update_successed;
            }
            catch (Exception e)
            {
                conn.Close();
                return e.Message;
            }
        }

        public static List<PSTonKho> ShowAllPSTonKho()
        {
            string query = "SELECT * FROM current.pstonkho";
            List<PSTonKho> listpstonkho = new List<PSTonKho>();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            
                var reader=cmd.ExecuteReader();
                while (reader.Read())
                {
                    listpstonkho.Add(new PSTonKho( reader.GetString(0), reader.GetDouble(1), reader.GetInt64(2), reader.GetInt64(3), reader.GetInt64(4), reader.GetInt64(5), reader.GetInt64(6)));
                }
                conn.Close();
                
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return listpstonkho;
        }

        public static PSTonKho ShowPSTonKho(string id)
        {
            string query = "SELECT * FROM current.pstonkho WHERE mahh=@mahh";
            PSTonKho pstonkho = new PSTonKho();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Varchar).Value = id;
                var reader = cmd.ExecuteReader();
                while (reader.Read()) { 
                    pstonkho = new PSTonKho(reader.GetString(0), reader.GetDouble(1), reader.GetInt64(2), reader.GetInt64(3), reader.GetInt64(4), reader.GetInt64(5), reader.GetInt64(6));
                }
                conn.Close();

            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return pstonkho;
        }

        public static string DeletePSTonKho(string id)
        {
            string query = "DELETE FROM current.pstonkho WHERE mahh=@mahh";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@mahh", NpgsqlDbType.Integer).Value = id;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Xóa thành công";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string LuuXuatTam(PSTonKho pstonkho)
        {
            return "";
        }
    }
}