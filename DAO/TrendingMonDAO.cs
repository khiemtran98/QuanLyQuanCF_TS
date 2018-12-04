using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class TrendingMonDAO
    {
        public static List<TrendingMonDTO> LayDanhSachTop10MonDaBan()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT TOP 10 ten_mon, SUM(so_luong) tong_so_luong FROM CTHoaDon INNER JOIN Mon ON mon=ma_mon INNER JOIN HoaDon ON HoaDon.ma_hoa_don=CTHoaDon.hoa_don WHERE HoaDon.trang_thai=1 GROUP BY ten_mon ORDER BY tong_so_luong DESC";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<TrendingMonDTO> result = new List<TrendingMonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TrendingMonDTO trendingMon = new TrendingMonDTO();
                    trendingMon.TenMon = reader.GetString(0);
                    trendingMon.SoLuong = reader.GetInt32(1);
                    result.Add(trendingMon);
                }
            }

            connection.Close();
            return result;
        }

    }
}
