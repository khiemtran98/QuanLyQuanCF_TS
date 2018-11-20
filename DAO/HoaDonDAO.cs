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

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        // Lấy danh sách theo khoảng thời gian
        public static List<HoaDonDTO> GetListBillByTime(DateTime dateFrom, DateTime dateEnd)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_hoa_don, nhan_vien_lap, ngay_lap, tong_tien, trang_thai FROM HoaDon WHERE (DATEPART(YYYY, ngay_lap) >= YEAR(@dateFrom) AND DATEPART(YYYY, ngay_lap) <= YEAR(@dateEnd)) AND (DATEPART(MM, ngay_lap) >= MONTH(@dateFrom) AND DATEPART(MM, ngay_lap) <= MONTH(@dateEnd)) AND (DATEPART(DD, ngay_lap) >= DAY(@dateFrom) AND DATEPART(DD, ngay_lap) <= DAY(@dateEnd)) ";
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@dateFrom", System.Data.SqlDbType.DateTime, 0).Value = dateFrom;
            command.Parameters.Add("@dateEnd", System.Data.SqlDbType.DateTime, 0).Value = dateEnd;
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<HoaDonDTO> result = new List<HoaDonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.MaHoaDon = reader.GetInt32(0);
                    hd.NhanVienLap = reader.GetInt32(1);
                    hd.NgayLap = reader.GetDateTime(2);
                    hd.TongTien = reader.GetDouble(3);
                    hd.TrangThai = reader.GetBoolean(4);
                    result.Add(hd);
                }
            }

            connection.Close();
            return result;
        }

        // Lấy hóa đơn một ngày cụ thể
        public static List<HoaDonDTO> GetListBillTimeline(DateTime timeLine)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_hoa_don, nhan_vien_lap, ngay_lap, tong_tien, trang_thai FROM HoaDon WHERE DATEPART(YYYY, ngay_lap) = YEAR(@timeLine) AND DATEPART(MM, ngay_lap) = MONTH(@timeLine) AND DATEPART(DD, ngay_lap) = DAY(@timeLine)";

            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@timeLine", System.Data.SqlDbType.DateTime, 0).Value = timeLine;
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<HoaDonDTO> result = new List<HoaDonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.MaHoaDon = reader.GetInt32(0);
                    hd.NhanVienLap = reader.GetInt32(1);
                    hd.NgayLap = reader.GetDateTime(2);
                    hd.TongTien = reader.GetDouble(3);
                    hd.TrangThai = reader.GetBoolean(4);
                    result.Add(hd);
                }
            }

            connection.Close();
            return result;
        }

        // Lấy toàn bộ danh sách hóa đơn.
        public static List<HoaDonDTO> GetEntireListBill()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_hoa_don, nhan_vien_lap, ngay_lap, tong_tien, tien_mat, tien_thua, trang_thai FROM HoaDon";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<HoaDonDTO> result = new List<HoaDonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.MaHoaDon = reader.GetInt32(0);
                    hd.NhanVienLap = reader.GetInt32(1);
                    hd.NgayLap = reader.GetDateTime(2);
                    hd.TongTien = reader.GetDouble(3);
                    hd.TienMat = reader.GetDouble(4);
                    hd.TienThua = reader.GetDouble(5);
                    hd.TrangThai = reader.GetBoolean(6);
                   
                    result.Add(hd);
                }
            }

            connection.Close();
            return result;
        }


    }
}
