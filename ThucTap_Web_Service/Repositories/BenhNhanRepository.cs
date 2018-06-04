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
    public class BenhNhanRepository
    {
        ConnectString connect = new ConnectString();
        public string GetConnectString()
        {
            return connect.connectionstring;
        }

        public static string AddBenhNhanToDB(BenhNhan benhnhan)
        {
            //Cấu trúc connection
            //var connectionstring = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456;Database=svthuctap;";

            //Quy định kiểu ngày sinh khi lấy từ Model
            string ngaysinh = benhnhan.ngaysinh;
            DateTime ngaysinhtemp = DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //var query2 = "INSERT INTO current.dmbenhnhan VALUES('" + benhnhan.mabn + "','" + benhnhan.holot + "','"+benhnhan.ten+"','"+ ngaysinhtemp + "',"+benhnhan.gioitinh+")";
            //Câu lệnh SQL thêm vào Database
            string query = "INSERT INTO current.dmbenhnhan VALUES(@mabn,@holot,@ten,@ngaysinh,@gioitinh)";

            //Get connectioin từ folder Conections
            BenhNhanRepository getstring = new BenhNhanRepository();
            string connectstring = getstring.GetConnectString();
            //Tạo kết nối tới PostgreSQL
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);
            
            //Try thêm dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = benhnhan.mabn;
                cmd.Parameters.Add("@holot", NpgsqlDbType.Varchar).Value = benhnhan.holot;
                cmd.Parameters.Add("@ten", NpgsqlDbType.Varchar).Value = benhnhan.ten;
                cmd.Parameters.Add("@ngaysinh", NpgsqlDbType.Date).Value = ngaysinhtemp;
                cmd.Parameters.Add("@gioitinh", NpgsqlDbType.Integer).Value = benhnhan.gioitinh;
                cmd.ExecuteNonQuery();
                conn.Close();
    
                return "Thêm thành công!";
            }
            // Bắt trường hợp lỗi
            catch (Exception e)
            {
                conn.Close();
                return e.Message;

            }
        }

        public static List<BenhNhan> ShowAllBenhNhanFromDB()
        {
            // Lấy connection
            BenhNhanRepository getstring = new BenhNhanRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn chọn hết dữ liệu từ Database
            var query = "SELECT * FROM current.dmbenhnhan";

            // Tạo List chứa dữ liệu
            List<BenhNhan> list = new List<BenhNhan>();

            //Tạo kết nối
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);


            // Lấy dữ liệu
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime temp = reader.GetDateTime(3);
                    string temp2 = temp.ToShortDateString();
          
                    var temp3 = reader.GetDecimal(4);
                    int temp4 = Decimal.ToInt32(temp3);
                    // Thêm vào list
                    list.Add(new BenhNhan(reader.GetString(0), reader.GetString(1),reader.GetString(2), temp2, temp4));
                }
                conn.Close();
                Console.WriteLine("Thành công");
                return list;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                return list;
            }
        }

        public static List<BenhNhan> ShowBenhNhanFromDB(String mabn)
        {
            //Lấy connection
            BenhNhanRepository getstring = new BenhNhanRepository();
            string connectstring = getstring.GetConnectString();

            //Câu truy vấn dữ liệu với điều kiện Mã bệnh nhân
            var query = "SELECT * FROM current.dmbenhnhan WHERE mabn = '"+mabn+"'";
           // var query = "SELECT * FROM current.dmbenhnhan WHERE mabn=@mabn'";
            List<BenhNhan> list = new List<BenhNhan>();
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn); ;
                //cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = mabn;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime temp = reader.GetDateTime(3);
                    string temp2 = temp.ToShortDateString();

                    var temp3 = reader.GetDecimal(4);
                    int temp4 = Decimal.ToInt32(temp3);
                    list.Add(new BenhNhan(reader.GetString(0), reader.GetString(1), reader.GetString(2), temp2, temp4));

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

        public static bool SuaThongTinBenhNhan(BenhNhan benhnhan)
        {
            BenhNhanRepository getstring = new BenhNhanRepository();
            string connectstring = getstring.GetConnectString();

            string temp = benhnhan.ngaysinh;
            // Câu lệnh cập nhật bệnh nhân dựa theo mã bệnh nhân,cập nhật dữ liệu các trường còn lại
            //var query = "UPDATE current.dmbenhnhan SET holot = '" + benhnhan.holot + "', ten = '" + benhnhan.ten + "', ngaysinh = '" + temp + "', gioitinh = '"+benhnhan.gioitinh+"' WHERE mabn = '"+benhnhan.mabn+"'";
            String query = "UPDATE current.dmbenhnhan SET holot=@holot,ten=@ten,ngaysinh=@ngaysinh,gioitinh=@gioitinh WHERE mabn=@mabn";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = benhnhan.mabn;
                cmd.Parameters.Add("@holot", NpgsqlDbType.Varchar).Value = benhnhan.holot;
                cmd.Parameters.Add("@ten", NpgsqlDbType.Varchar).Value = benhnhan.ten;
                cmd.Parameters.Add("@ngaysinh", NpgsqlDbType.Date).Value = temp;
                cmd.Parameters.Add("@gioitinh", NpgsqlDbType.Integer).Value = benhnhan.gioitinh;
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

        public static bool XoaBenhNhan(string mabn)
        {
            BenhNhanRepository getstring = new BenhNhanRepository();
            string connectstring = getstring.GetConnectString();

            // Câu truy vấn xoá bệnh nhân với Mã bệnh nhân
            //var query = "DELETE FROM current.dmbenhnhan WHERE mabn = '"+mabn+"'";
            var query = "DELETE FROM current.dmbenhnhan WHERE mabn =@mabn";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.Add("@mabn", NpgsqlDbType.Varchar).Value = mabn;
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

        public static string ThongKe()
        {
            BenhNhanRepository getstring = new BenhNhanRepository();
            string connectstring = getstring.GetConnectString();


            //var query = "SELECT gioitinh,count(*) FROM current.dmbenhnhan GROUP BY gioitinh";
            var query = "SELECT gt.gioitinh,  coalesce(COUNT(dm.gioitinh),0) as soluong FROM current.dmbenhnhan as dm RIGHT JOIN current.dmgioitinh as gt on dm.gioitinh = gt.gioitinh GROUP BY gt.gioitinh";
            NpgsqlConnection conn = new NpgsqlConnection(connectstring);
            string soluongnu="", soluongnam="", soluongkxd="";
            List<string> result = new List<string>();
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn); ;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string gioitinh = reader.GetString(0);
                    string soluong = reader.GetString(1);
                    if (gioitinh == "0")
                        soluongnu = soluong;
                    else if (gioitinh == "1")
                        soluongnam = soluong;
                    else
                        soluongkxd = soluong;

                }
                conn.Close();
                result.Add(soluongnu);
                result.Add(soluongnam);
                result.Add(soluongkxd);
                string ketqua = JsonConvert.SerializeObject(result);

                return ketqua;
            }
            catch(Exception e)
            {
                conn.Close();
                return e.Message;
            }
        }
    }
}