using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class LoaiMonDAO
    {
        public static int LayMaLoaiMonMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT MAX(ma_loai_mon) FROM LoaiMon";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int result = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();
            return result;
        }

        public static List<LoaiMonDTO> LayDanhSachLoaiMon(string timKiem, bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_loai_mon, ten_loai_mon, la_do_uong, trang_thai FROM LoaiMon WHERE 1=1";
            SqlCommand command = new SqlCommand();
            if (timKiem != "")
            {
                query += " AND ten_loai_mon LIKE N'%'+@timKiem+'%'";
                command.Parameters.Add("@timKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }
            if (trangThai)
            {
                query += " AND trang_thai=1";
            }

            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            List<LoaiMonDTO> result = new List<LoaiMonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiMonDTO loaiMon = new LoaiMonDTO();
                    loaiMon.MaLoaiMon = reader.GetInt32(0);
                    loaiMon.TenLoaiMon = reader.GetString(1);
                    loaiMon.LaDoUong = reader.GetBoolean(2);
                    loaiMon.TrangThai = reader.GetBoolean(3);
                    result.Add(loaiMon);
                }
            }


            connection.Close();
            return result;
        }
        public static List<LoaiMonDTO> LayDanhSachLoaiMon()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT * FROM LoaiMon ";
            SqlCommand command = new SqlCommand();

            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<LoaiMonDTO> result = new List<LoaiMonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiMonDTO loaiMon = new LoaiMonDTO();
                    loaiMon.MaLoaiMon = reader.GetInt32(0);
                    loaiMon.TenLoaiMon = reader.GetString(1);
                    loaiMon.LaDoUong = reader.GetBoolean(2);
                    loaiMon.TrangThai = reader.GetBoolean(3);
                    result.Add(loaiMon);
                }
            }

            connection.Close();
            return result;
        }
        public static bool ThemLoaiMon(LoaiMonDTO loaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO LoaiMon (ten_loai_mon, la_do_uong, trang_thai) VALUES (@tenLoaiMon, @laDoUong, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.Add("@tenLoaiMon", System.Data.SqlDbType.NVarChar, 255).Value = loaiMon.TenLoaiMon;
            command.Parameters.Add("@laDoUong", System.Data.SqlDbType.Bit, 0).Value = loaiMon.LaDoUong;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = loaiMon.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool XoaLoaiMon(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM LoaiMon WHERE ma_loai_mon=@maLoaiMon";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.NVarChar, 255).Value = maLoaiMon;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool SuaLoaiMon(LoaiMonDTO loaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE LoaiMon SET ten_loai_mon=@tenLoaiMon, la_do_uong=@laDoUong, trang_thai=@trangThai WHERE ma_loai_mon=@maLoaiMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = loaiMon.MaLoaiMon;
            command.Parameters.Add("@tenLoaiMon", System.Data.SqlDbType.NVarChar, 255).Value = loaiMon.TenLoaiMon;
            command.Parameters.Add("@laDoUong", System.Data.SqlDbType.Bit, 0).Value = loaiMon.LaDoUong;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = loaiMon.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }
    }
}
