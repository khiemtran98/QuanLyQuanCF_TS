using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class LoaiToppingDAO
    {
        public static List<LoaiToppingDTO> LayDanhSachLoaiTopping(string timKiem, bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_loai_topping, ten_loai_topping, trang_thai FROM LoaiTopping WHERE 1=1";
            SqlCommand command = new SqlCommand();
            if (timKiem != "")
            {
                query += " AND ten_loai_topping LIKE N'%'+@timKiem+'%'";
                command.Parameters.Add("@timKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }
            if (trangThai)
            {
                query += " AND trang_thai=1";
            }
            else
            {
                query += " AND trang_thai=0";
            }
            command.Connection = connection;
            command.CommandText = query;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<LoaiToppingDTO> result = new List<LoaiToppingDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiToppingDTO loaiTopping = new LoaiToppingDTO();
                    loaiTopping.MaLoaiTopping = reader.GetInt32(0);
                    loaiTopping.TenLoaiTopping = reader.GetString(1);
                    loaiTopping.TrangThai = reader.GetBoolean(2);
                    result.Add(loaiTopping);
                }
            }

            connection.Close();
            return result;
        }

        public static List<LoaiToppingDTO> LayDanhSachTatCaLoaiTopping()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_loai_topping, ten_loai_topping, trang_thai FROM LoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<LoaiToppingDTO> result = new List<LoaiToppingDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiToppingDTO loaiTopping = new LoaiToppingDTO();
                    loaiTopping.MaLoaiTopping = reader.GetInt32(0);
                    loaiTopping.TenLoaiTopping = reader.GetString(1);
                    loaiTopping.TrangThai = reader.GetBoolean(2);
                    result.Add(loaiTopping);
                }
            }

            connection.Close();
            return result;
        }

        public static List<LoaiToppingDTO> LayDanhSachCTLoaiMon_LoaiTopping(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT DISTINCT LoaiTopping.ma_loai_topping, LoaiTopping.ten_loai_topping FROM CTLoaiMon_LoaiTopping,LoaiTopping WHERE CTLoaiMon_LoaiTopping.ma_loai_topping=LoaiTopping.ma_loai_topping AND CTLoaiMon_LoaiTopping.ma_loai_mon=@maLoaiMon AND LoaiTopping.trang_thai=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;

            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<LoaiToppingDTO> result = new List<LoaiToppingDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiToppingDTO loaiTopping = new LoaiToppingDTO();
                    loaiTopping.MaLoaiTopping = reader.GetInt32(0);
                    loaiTopping.TenLoaiTopping = reader.GetString(1);
                    result.Add(loaiTopping);
                }
            }
            command.Connection.Close();
            return result;
        }

        public static bool ThemLoaiTopping(LoaiToppingDTO loaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO LoaiTopping (ten_loai_topping, trang_thai) VALUES (@tenLoaiTopping, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@tenLoaiTopping", System.Data.SqlDbType.NVarChar, 255).Value = loaiTopping.TenLoaiTopping;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = loaiTopping.TrangThai;

            command.Connection.Open();
            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool XoaLoaiTopping(int maLoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE LoaiTopping SET trang_thai=0 WHERE ma_loai_topping=@maLoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;

            command.Connection.Open();
            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool SuaLoaiTopping(LoaiToppingDTO loaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE LoaiTopping SET ten_loai_topping=@tenLoaiTopping, trang_thai=@trangThai WHERE ma_loai_topping=@maLoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = loaiTopping.MaLoaiTopping;
            command.Parameters.Add("@tenLoaiTopping", System.Data.SqlDbType.NVarChar, 255).Value = loaiTopping.TenLoaiTopping;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = loaiTopping.TrangThai;

            command.Connection.Open();
            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool KhoiPhucLoaiTopping(int maLoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE LoaiTopping SET trang_thai=1 WHERE ma_loai_topping=@maLoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;

            command.Connection.Open();
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
