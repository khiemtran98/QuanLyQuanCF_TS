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

            if (reader == 1)
            {
                return true;
            }
            return false;
        }
    }
}
