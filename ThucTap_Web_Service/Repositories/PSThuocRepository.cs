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
    public class PSThuocRepository
    {
        private static string connectstring = new ConnectString().GetConnectString();
        private static NpgsqlConnection conn = new NpgsqlConnection(connectstring);
        public static ThongBao tb = new ThongBao();
        public static string AddPSThuoc(PSThuoc psthuoc)
        {
            string query = "INSERT INTO current.psthuoc VALUES(@Idpsthuoc,@Iddienbien,@mabn,@maba,@makhoa,@thanhtien)";
            NpgsqlCommand cmd = new NpgsqlCommand(query,conn);
            try
            {
                conn.Open();
                cmd.Parameters.Add("@Idpsthuoc", NpgsqlDbType.Varchar).Value = psthuoc.Idpsthuoc;
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value = psthuoc.Iddienbien;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = psthuoc.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = psthuoc.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = psthuoc.Makhoa;
                cmd.Parameters.Add("@thanhtien", NpgsqlDbType.Numeric).Value = psthuoc.Thanhtien;
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

        public static string UpdatePSThuoc(PSThuoc psthuoc)
        {
            string query = "UPDATE current.psthuoc SET Iddienbien=@Iddienbien,mabn=@mabn,maba=@maba,makhoa=@makhoa,thanhtien=@thanhtien WHERE Idpsthuoc=@Idpsthuoc";
          
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@Idpsthuoc", NpgsqlDbType.Varchar).Value = psthuoc.Idpsthuoc;
                cmd.Parameters.Add("@Iddienbien", NpgsqlDbType.Varchar).Value = psthuoc.Iddienbien;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = psthuoc.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = psthuoc.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = psthuoc.Makhoa;
                cmd.Parameters.Add("@thanhtien", NpgsqlDbType.Numeric).Value = psthuoc.Thanhtien;
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

        

        public static List<PSThuoc> ShowAllPSThuoc()
        {
            List<PSThuoc> listpsthuoc = new List<PSThuoc>();
            string query = "SELECT * FROM current.psthuoc";
      
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                var reader=cmd.ExecuteReader();
                while (reader.Read())
                {
                    listpsthuoc.Add(new PSThuoc(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5)));
                }
                conn.Close();
                

            }
            catch(Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return listpsthuoc;

        }

        public static PSThuoc ShowPSThuoc(string id)
        {
            PSThuoc psthuoc = new PSThuoc();
            string query = "SELECT * FROM current.psthuoc WHERE Idpsthuoc=@Idpsthuoc";
          
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@Idpsthuoc", NpgsqlDbType.Varchar).Value = id;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    psthuoc=new PSThuoc(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5));
                }
                conn.Close();


            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return psthuoc;

        }

        public static string DeletePSThuoc(string id)
        {
            string query = "DELETE FROM current.psthuoc WHERE Idpsthuoc=@Idpsthuoc";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@Idpsthuoc", NpgsqlDbType.Varchar).Value = id;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Xóa thành công";
            }
            catch(Exception e)
            {
                conn.Close();
                return e.Message;
            }
        }

    }
}