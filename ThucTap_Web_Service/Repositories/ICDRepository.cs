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
    public class ICDRepository
    {
        private static string connectstring = new ConnectString().GetConnectString();
        private static NpgsqlConnection conn = new NpgsqlConnection(connectstring);

        public static List<ICD> ShowAllICD()
        {
            string query = "SELECT * FROM current.dmicd";
            List<ICD> listicd = new List<ICD>();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listicd.Add(new ICD(reader.GetString(0), reader.GetString(1)));
                }
                conn.Close();

            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return listicd;
        }

        public static ICD ShowICD(string id)
        {
            string query = "SELECT * FROM current.dmicd WHERE maicd=@maicd";
            ICD icd = new ICD();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@maicd", NpgsqlDbType.Varchar).Value = id;
                var reader = cmd.ExecuteReader();

                icd = new ICD(reader.GetString(0), reader.GetString(1));

                conn.Close();

            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return icd;
        }
    }
}