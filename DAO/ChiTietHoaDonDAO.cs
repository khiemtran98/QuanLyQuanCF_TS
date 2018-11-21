using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class ChiTietHoaDonDAO
    {
        public static int LayMaChiTietHoaDonMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT MAX(ma_cthd) FROM ChiTietHoaDon";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            return result is DBNull ? 0 : Convert.ToInt32(result);
        }

        public static bool LuuChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO ChiTietHoaDon (hoa_don, mon, so_luong, don_gia, ghi_chu) VALUES (@MaHoaDon, @MaMon, @SoLuong, @DonGia, @GhiChu)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@MaHoaDon", System.Data.SqlDbType.Int, 0).Value = chiTietHoaDon.MaHoaDon;
            command.Parameters.Add("@MaMon", System.Data.SqlDbType.Int, 0).Value = chiTietHoaDon.MaMon;
            command.Parameters.Add("@SoLuong", System.Data.SqlDbType.Int, 0).Value = chiTietHoaDon.SoLuong;
            command.Parameters.Add("@DonGia", System.Data.SqlDbType.Float, 0).Value = chiTietHoaDon.DonGia;
            command.Parameters.Add("@GhiChu", System.Data.SqlDbType.NVarChar, 255).Value = chiTietHoaDon.GhiChu;

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
