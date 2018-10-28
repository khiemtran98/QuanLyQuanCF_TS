using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class CTHoaDon
    {
        public static int LayMaCTHoaDonMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT MAX(ma_cthd) FROM CTHoaDon";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            return result is DBNull ? 0 : Convert.ToInt32(result);
        }

        public static bool LuuCTHoaDon(CTHoaDonDTO CTHoaDon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO CTHoaDon (hoa_don, mon, so_luong, don_gia, ghi_chu) VALUES (@maHoaDon, @maMon, @soLuong, @donGia, @ghiChu)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maHoaDon", System.Data.SqlDbType.Int, 0).Value = CTHoaDon.MaHoaDon;
            command.Parameters.Add("@maMon", System.Data.SqlDbType.Int, 0).Value = CTHoaDon.MaMon;
            command.Parameters.Add("@soLuong", System.Data.SqlDbType.Int, 0).Value = CTHoaDon.SoLuong;
            command.Parameters.Add("@donGia", System.Data.SqlDbType.Float, 0).Value = CTHoaDon.DonGia;
            command.Parameters.Add("@ghiChu", System.Data.SqlDbType.NVarChar, 255).Value = CTHoaDon.GhiChu;

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
