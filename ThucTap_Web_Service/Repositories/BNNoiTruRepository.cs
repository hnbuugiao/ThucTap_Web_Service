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
    public class BNNoiTruRepository
    {
        private static string connectstring = new ConnectString().GetConnectString();
        private static NpgsqlConnection conn = new NpgsqlConnection(connectstring);
        public static ThongBao tb = new ThongBao();
        public static string AddBNNoiTru(BNNoiTru bnnoitru)
        {
            string query = "INSERT INTO current.bnnoitru(mabn,maba,makhoa,maicd,tenicd,maicdp,tenicdp) VALUES(@mabn,@maba,@makhoa,@maicd,@tenicd,@maicdp,@tenicdp)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = bnnoitru.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = bnnoitru.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = bnnoitru.Makhoa;
                cmd.Parameters.Add("@maicd", NpgsqlDbType.Varchar).Value = bnnoitru.Maicd;
                cmd.Parameters.Add("@tenicd", NpgsqlDbType.Varchar).Value = bnnoitru.Tenicdp;
                cmd.Parameters.Add("@maicdp", NpgsqlDbType.Varchar).Value = bnnoitru.Maicdp;
                cmd.Parameters.Add("@tenicdp", NpgsqlDbType.Varchar).Value = bnnoitru.Tenicdp;
                cmd.ExecuteNonQuery();
                conn.Close();
                return tb.add_successed;
            }
            catch (Exception e)
            {
                conn.Close();
                return e.Message;
            }
        }

        public static string UpdateBNNoiTru(BNNoiTru bnnoitru)
        {
            string query = "UPDATE current.bnnoitru SET mabn=@mabn,maba=@maba,makhoa=@makhoa,maicd=@maicd,tenicd=@tenicd,maicdp=@maicdp,tenicdp=@tenicdp WHERE ID=@ID";

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@ID", NpgsqlDbType.Integer).Value = bnnoitru.ID;
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = bnnoitru.Mabn;
                cmd.Parameters.Add("@maba", NpgsqlDbType.Varchar).Value = bnnoitru.Maba;
                cmd.Parameters.Add("@makhoa", NpgsqlDbType.Varchar).Value = bnnoitru.Makhoa;
                cmd.Parameters.Add("@maicd", NpgsqlDbType.Varchar).Value = bnnoitru.Maicd;
                cmd.Parameters.Add("@tenicd", NpgsqlDbType.Varchar).Value = bnnoitru.Tenicdp;
                cmd.Parameters.Add("@maicdp", NpgsqlDbType.Varchar).Value = bnnoitru.Maicdp;
                cmd.Parameters.Add("@tenicdp", NpgsqlDbType.Varchar).Value = bnnoitru.Tenicdp;
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

        public static List<BNNoiTru> ShowAllBNNoiTru()
        {
            List<BNNoiTru> listbnnoitru = new List<BNNoiTru>();
            string query = "SELECT * FROM current.bnnoitru";

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listbnnoitru.Add(new BNNoiTru(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),reader.GetString(6),reader.GetString(7)));
                }
                conn.Close();


            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return listbnnoitru;

        }

        public static BNNoiTru ShowBNNoiTru(int id)
        {
            BNNoiTru bnnoitru = new BNNoiTru();
            string query = "SELECT * FROM current.bnnoitru WHERE ID=@ID";

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@ID", NpgsqlDbType.Integer).Value = id;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bnnoitru =new BNNoiTru(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                }
                conn.Close();


            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return bnnoitru;

        }

        public static string DeleteBNNoiTru(int id)
        {
            string query = "DELETE FROM current.bnnoitru WHERE ID=@ID";
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
                conn.Close();
                return e.Message;
            }
        }
    }
}