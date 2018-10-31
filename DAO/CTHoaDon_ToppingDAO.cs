using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class CTHoaDon_ToppingDAO
    {
        public static bool LuuCTHoaDon_Topping(CTHoaDon_ToppingDTO CTHoaDon_Topping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO CTHoaDon_Topping (ma_cthd, ma_topping, so_luong, don_gia, ghi_chu) VALUES (@maCTHD, @maTopping, @soLuong, @donGia, @ghiChu)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maCTHD", System.Data.SqlDbType.Int, 0).Value = CTHoaDon_Topping.MaCTHD;
            command.Parameters.Add("@maTopping", System.Data.SqlDbType.Int, 0).Value = CTHoaDon_Topping.MaTopping;
            command.Parameters.Add("@soLuong", System.Data.SqlDbType.Int, 0).Value = CTHoaDon_Topping.SoLuong;
            command.Parameters.Add("@donGia", System.Data.SqlDbType.Float, 0).Value = CTHoaDon_Topping.DonGia;
            command.Parameters.Add("@ghiChu", System.Data.SqlDbType.NVarChar, 255).Value = CTHoaDon_Topping.GhiChu;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static List<CTHoaDon_ToppingDTO> LayDanhSachTopping(int maHoaDon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_cthd, ma_topping, so_luong, don_gia, ghi_chu FROM CTHoaDon_Topping WHERE 1=1";
            SqlCommand command = new SqlCommand();
      
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CTHoaDon_ToppingDTO> result = new List<CTHoaDon_ToppingDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CTHoaDon_ToppingDTO topping = new CTHoaDon_ToppingDTO();
                    topping.MaCTHD = reader.GetInt32(0);
                    topping.MaTopping = reader.GetInt32(1);
                    topping.SoLuong = reader.GetInt32(2);
                    topping.DonGia = reader.GetDouble(3);
                    topping.GhiChu = reader.GetString(4);
                    result.Add(topping);
                }
            }

            connection.Close();
            return result;
        }
    }
}
