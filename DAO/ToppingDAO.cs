using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ToppingDAO
    {
        public static List<ToppingDTO> LayDanhSachTopping(int maLoaiTopping, string timKiem, bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();

            string query = "SELECT ma_topping, ten_topping, loai_topping, gia_tien, hinh, trang_thai FROM Topping WHERE 1=1";
            SqlCommand command = new SqlCommand();
            if (maLoaiTopping != 0)
            {
                query += " AND loai_topping=@MaLoaiTopping";
                command.Parameters.Add("@MaLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;
            }
            if (timKiem != "")
            {
                query += " AND ten_topping LIKE N'%'+@TimKiem+'%'";
                command.Parameters.Add("@TimKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }
            if (trangThai)
            {
                query += " AND trang_thai=1";
            }
            else
            {
                query += " AND trang_thai=0";
            }
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<ToppingDTO> result = new List<ToppingDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ToppingDTO topping = new ToppingDTO();
                    topping.MaTopping = reader.GetInt32(0);
                    topping.TenTopping = reader.GetString(1);
                    topping.LoaiTopping = reader.GetInt32(2);
                    topping.GiaTien = reader.GetDouble(3);
                    topping.Hinh = reader.GetString(4);
                    topping.TrangThai = reader.GetBoolean(5);
                    result.Add(topping);
                }
            }

            connection.Close();
            return result;
        }

        public static bool XoaToppingTheoLoai(int maLoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE Topping SET trang_thai=0 WHERE loai_topping=@maLoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            return true;
        }

        public static int LaySoLuongToppingTheoLoai(int maLoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT COUNT(ma_topping) FROM Topping WHERE trang_thai=1";
            SqlCommand command = new SqlCommand();
            if (maLoaiTopping != 0)
            {
                query += " AND loai_topping=@MaLoaiTopping";
                command.Parameters.Add("@MaLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;
            }
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            int result = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();
            return result;
        }

        public static int LayMaToppingMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT MAX(ma_topping) FROM Topping";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            return result is DBNull ? 0 : Convert.ToInt32(result);
        }

        public static bool ThemTopping(ToppingDTO topping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO Topping (ten_topping, loai_topping, gia_tien, hinh, trang_thai) VALUES (@tenTopping, @loaiTopping, @giaTien, @hinh, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@tenTopping", System.Data.SqlDbType.NVarChar, 255).Value = topping.TenTopping;
            command.Parameters.Add("@loaiTopping", System.Data.SqlDbType.Int, 0).Value = topping.LoaiTopping;
            command.Parameters.Add("@giaTien", System.Data.SqlDbType.Float, 0).Value = topping.GiaTien;
            command.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = topping.Hinh;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = topping.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool XoaTopping(int maTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE Topping SET trang_thai=0 WHERE ma_topping=@maTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maTopping", System.Data.SqlDbType.Int, 0).Value = maTopping;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool SuaTopping(ToppingDTO topping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE Topping SET ten_topping=@tenTopping, loai_topping=@loaiTopping, gia_tien=@giaTien, hinh=@hinh, trang_thai=@trangThai WHERE ma_topping=@maTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maTopping", System.Data.SqlDbType.Int, 0).Value = topping.MaTopping;
            command.Parameters.Add("@tenTopping", System.Data.SqlDbType.NVarChar, 255).Value = topping.TenTopping;
            command.Parameters.Add("@loaiTopping", System.Data.SqlDbType.Int, 0).Value = topping.LoaiTopping;
            command.Parameters.Add("@giaTien", System.Data.SqlDbType.Float, 0).Value = topping.GiaTien;
            command.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = topping.Hinh;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = topping.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool KhoiPhucTopping(int maTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE Topping SET trang_thai=1 WHERE ma_topping=@maTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maTopping", System.Data.SqlDbType.Int, 0).Value = maTopping;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool KhoiPhucToppingTheoLoai(int maLoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE Topping SET trang_thai=1 WHERE loai_topping=@maLoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            return true;
        }
    }
}
