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
        public static List<LoaiToppingDTO> LayDanhSachLoaiTopping(string timKiem = "")
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_loai_topping, ten_loai_topping, trang_thai FROM LoaiTopping WHERE trang_thai=1";
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

        public static List<LoaiToppingDTO> LayDanhSachLoaiToppingTheoLoaiMon(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT DISTINCT LoaiTopping.ma_loai_topping, LoaiTopping.ten_loai_topping FROM CTLoaiMon_LoaiTopping,LoaiTopping WHERE CTLoaiMon_LoaiTopping.ma_loai_topping=LoaiTopping.ma_loai_topping AND CTLoaiMon_LoaiTopping.ma_loai_mon=@maLoaiMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int,0).Value = maLoaiMon;

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

        public static List<LoaiToppingDTO> LayDanhSachLoaiToppingTheoMon(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_loai_topping, ten_loai_topping, loai_mon, trang_thai FROM LoaiTopping WHERE loai_mon=@maLoaiMon AND trang_thai=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;

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
                    //loaiTopping.LoaiMon = reader.GetInt32(2);
                    loaiTopping.TrangThai = reader.GetBoolean(3);
                    result.Add(loaiTopping);
                }
            }

            connection.Close();
            return result;
        }

        public static bool ThemLoaiTopping(LoaiToppingDTO loaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO LoaiTopping(ma_loai_topping, ten_loai_topping, loai_mon, trang_thai) VALUES (@maLoaiTopping, @tenLoaiTopping, @loaiMon, @trangThai)";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = loaiTopping.MaLoaiTopping;
            command.Parameters.Add("@tenLoaiTopping", System.Data.SqlDbType.NVarChar, 255).Value = loaiTopping.TenLoaiTopping;
            //command.Parameters.Add("@loaiMon", System.Data.SqlDbType.NVarChar, 255).Value = loaiTopping.LoaiMon;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = loaiTopping.TrangThai;

            command.Connection.Open();
            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool XoaLoaiTopping(LoaiToppingDTO loaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE LoaiTopping SET ten_loai_topping=@tenLoaiTopping, loai_mon=@loaiMon, trang_thai=@trangThai WHERE ma_loai_topping=@maLoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = loaiTopping.MaLoaiTopping;
            command.Parameters.Add("@tenLoaiTopping", System.Data.SqlDbType.NVarChar, 255).Value = loaiTopping.TenLoaiTopping;
            //command.Parameters.Add("@loaiMon", System.Data.SqlDbType.NVarChar, 255).Value = loaiTopping.LoaiMon;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = loaiTopping.TrangThai;

            command.Connection.Open();
            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool SuaLoaiTopping(int maLoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM LoaiTopping WHERE MaLoaiTopping=@maLoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;

            command.Connection.Open();
            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }
    }
}
