using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class HoaDonDAO
    {
        public static int LayMaHoaDonMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT MAX(ma_hoa_don) FROM HoaDon";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();
            
            return result is DBNull ? 0 : Convert.ToInt32(result);
        }

        public static bool LuuHoaDon(HoaDonDTO hoaDon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO HoaDon (nhan_vien_lap, ngay_lap, tong_tien, trang_thai) VALUES (@nhanVienLap, @ngayLap, @tongTien, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@nhanVienLap", System.Data.SqlDbType.Int, 0).Value = hoaDon.NhanVienLap;
            command.Parameters.Add("@ngayLap", System.Data.SqlDbType.DateTime, 0).Value = hoaDon.NgayLap;
            command.Parameters.Add("@tongTien", System.Data.SqlDbType.Float, 0).Value = hoaDon.TongTien;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = hoaDon.TrangThai;

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
