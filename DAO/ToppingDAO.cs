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
        public static List<ToppingDTO> LayDanhSachToppingTheoLoai(int maLoaiTopping, string timKiem = "")
        {
            SqlConnection connection = DataProvider.GetConnection();

            string query = "SELECT ma_topping, ten_topping, loai_topping, gia_tien FROM Topping WHERE trang_thai=1";
            SqlCommand command = new SqlCommand();
            if (maLoaiTopping != 0)
            {
                query += " AND loai_topping=@MaLoaiTopping";
                command.Parameters.Add("@MaLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;
            }
            if (timKiem != string.Empty)
            {
                query += " AND ten_topping LIKE N'%'+@TimKiem+'%'";
                command.Parameters.Add("@TimKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }
            command.CommandText = query;
            command.Connection = connection;
            //string query;
            //if (timKiem == string.Empty)
            //{
            //    query = "SELECT ma_topping, ten_topping, loai_topping, gia_tien FROM Topping WHERE loai_topping=@MaLoaiTopping AND trang_thai=1";
            //}
            //else
            //{
            //    query = "SELECT ma_topping, ten_topping, loai_topping, gia_tien FROM Topping WHERE loai_topping=@MaLoaiTopping AND ten_topping LIKE N'%'+@TimKiem+'%' AND trang_thai=1";
            //}
            //SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.Add("@MaLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;
            //command.Parameters.Add("@TimKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;

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
