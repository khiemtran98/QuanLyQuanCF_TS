using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class ChiTietMonDAO
    {
        public static bool LuuChiTietMon(ChiTietMonDTO chiTietMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO ChiTietMon (ma_cthd, ma_topping, so_luong, don_gia) VALUES (@MaCTHD, @MaTopping, @SoLuong, @DonGia)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@MaCTHD", System.Data.SqlDbType.Int, 0).Value = chiTietMon.MaCTHD;
            command.Parameters.Add("@MaTopping", System.Data.SqlDbType.Int, 255).Value = chiTietMon.MaTopping;
            command.Parameters.Add("@SoLuong", System.Data.SqlDbType.Int, 255).Value = chiTietMon.SoLuong;
            command.Parameters.Add("@DonGia", System.Data.SqlDbType.Int, 255).Value = chiTietMon.DonGia;

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
