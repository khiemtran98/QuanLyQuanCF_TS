using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class PhieuNhapDAO
    {
        // Lấy toàn bộ phiếu nhập
        public static List<PhieuNhapDTO> GetEntireInputMeterial()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_phieu_nhap, nha_cung_cap, ngay_lap, tong_tien, trang_thai FROM PhieuNhap";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<PhieuNhapDTO> result = new List<PhieuNhapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PhieuNhapDTO pn = new PhieuNhapDTO();
                    pn.MaPhieuNhap = reader.GetInt32(0);
                    pn.NhaCungCap = reader.GetInt32(1);
                    pn.NgayLap = reader.GetDateTime(2);
                    pn.TongTien = reader.GetDouble(3);
                    pn.TrangThai = reader.GetBoolean(4);
                    result.Add(pn);
                }
            }

            connection.Close();
            return result;
        }

        // Lấy danh sách PhieuNhap theo khoảng thời gian
        public static List<PhieuNhapDTO> GetListInputByTime(DateTime dateFrom, DateTime dateEnd)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_phieu_nhap, nha_cung_cap, ngay_lap, tong_tien, trang_thai FROM PhieuNhap WHERE (DATEPART(YYYY, ngay_lap) >= YEAR(@dateFrom) AND DATEPART(YYYY, ngay_lap) <= YEAR(@dateEnd)) AND (DATEPART(MM, ngay_lap) >= MONTH(@dateFrom) AND DATEPART(MM, ngay_lap) <= MONTH(@dateEnd)) AND (DATEPART(DD, ngay_lap) >= DAY(@dateFrom) AND DATEPART(DD, ngay_lap) <= DAY(@dateEnd)) ";
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@dateFrom", System.Data.SqlDbType.DateTime, 0).Value = dateFrom;
            command.Parameters.Add("@dateEnd", System.Data.SqlDbType.DateTime, 0).Value = dateEnd;
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<PhieuNhapDTO> result = new List<PhieuNhapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PhieuNhapDTO pn = new PhieuNhapDTO();
                    pn.MaPhieuNhap = reader.GetInt32(0);
                    pn.NhaCungCap = reader.GetInt32(1);
                    pn.NgayLap = reader.GetDateTime(2);
                    pn.TongTien = reader.GetDouble(3);
                    pn.TrangThai = reader.GetBoolean(4);
                    result.Add(pn);
                }
            }

            connection.Close();
            return result;
        }

        // Lấy phiếu nhập một ngày cụ thể
        public static List<PhieuNhapDTO> GetListInputTimeline(DateTime timeLine)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_phieu_nhap, nha_cung_cap, ngay_lap, tong_tien, trang_thai FROM PhieuNhap WHERE DATEPART(YYYY, ngay_lap) = YEAR(@timeLine) AND DATEPART(MM, ngay_lap) = MONTH(@timeLine) AND DATEPART(DD, ngay_lap) = DAY(@timeLine)";

            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@timeLine", System.Data.SqlDbType.DateTime, 0).Value = timeLine;
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<PhieuNhapDTO> result = new List<PhieuNhapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PhieuNhapDTO pn = new PhieuNhapDTO();
                    pn.MaPhieuNhap = reader.GetInt32(0);
                    pn.NhaCungCap = reader.GetInt32(1);
                    pn.NgayLap = reader.GetDateTime(2);
                    pn.TongTien = reader.GetDouble(3);
                    pn.TrangThai = reader.GetBoolean(4);
                    result.Add(pn);
                }
            }

            connection.Close();
            return result;
        }



    }
}
