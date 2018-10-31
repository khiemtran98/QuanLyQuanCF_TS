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

            string query = "SELECT ma_topping, ten_topping, loai_topping, gia_tien FROM Topping WHERE 1=1";
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
                    result.Add(topping);
                }
            }

            connection.Close();
            return result;
        }

        public static bool XoaToppingTheoLoai(int maLoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM Topping WHERE loai_topping=@maLoaiTopping";
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
    }
}
