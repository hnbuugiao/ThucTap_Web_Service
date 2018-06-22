using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucTap_Web_Service.Connections;
using NpgsqlTypes;
using ThucTap_Web_Service.Models;

namespace ThucTap_Web_Service.Repositories
{
   
    public class BenhAnRepository
    {
        public static ThongBao tb = new ThongBao();
        private static string connectstring = new ConnectString().GetConnectString();
        private static NpgsqlConnection conn = new NpgsqlConnection(connectstring);
        public static string AddBenhAn(BenhAn ba)
        {
            string query = "INSERT INTO current.dmbenhan VALUES(@maba,@mabn,@ngaylap)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = ba.Maba;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = ba.Mabn;
                cmd.Parameters.Add("@ngaylap", NpgsqlDbType.Date).Value = ba.Ngaylap;
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

        public static string UpdateBenhAn(BenhAn ba)
        {
            string query = "UPDATE current.dmbenhan SET mabn=@mabn,ngaylap=@ngaylap WHERE maba=@maba";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = ba.Maba;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = ba.Mabn;
                cmd.Parameters.Add("@ngaylap", NpgsqlDbType.Date).Value = ba.Ngaylap;
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

        public static List<BenhAn> ShowAllBenhAn()
        {
            string query = "SELECT * FROM current.dmbenhan";
            NpgsqlCommand cmd = new NpgsqlCommand(query,conn);
            List<BenhAn> listba =new List<BenhAn>();
            try
            {
                conn.Open();
                var reader=cmd.ExecuteReader();
                while (reader.Read())
                {
       
                    listba.Add(new BenhAn(reader.GetString(0),reader.GetString(1),reader.GetDateTime(2).ToShortDateString()));
                }
                conn.Close();
            }
            catch(Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);

            }
            return listba;
        }

        public static BenhAn ShowBenhAn(string maba)
        {
            string query = "SELECT * FROM current.dmbenhan WHERE maba=@maba";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            BenhAn ba = new BenhAn();
            try

            {
                conn.Open();
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = maba;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ba = new BenhAn(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2).ToShortDateString());
                }
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);

            }
            return ba;
        }

        public static string DeleteBenhAn(string maba)
        {
            string query = "DELETE FROM current.dmbenhan WHERE maba=@maba";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
    
            try
            {
                conn.Open();
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = maba;
                var reader = cmd.ExecuteNonQuery();
                return "Xóa thành công";

            }
            catch (Exception e)
            {
                conn.Close();
                return e.Message;

            }
       
        }

    }
}