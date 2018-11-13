using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class PhieuNhapDAO
    {
        public static int LayMaPhieuNhapMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT MAX(ma_phieu_nhap) FROM PhieuNhap";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            return result is DBNull ? 0 : Convert.ToInt32(result);
        }

        public static bool LuuPhieuNhap(PhieuNhapDTO phieuNhap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO PhieuNhap (nha_cung_cap, ngay_lap, tong_tien, trang_thai) VALUES (@nhaCungCap, @ngayLap, @tongTien, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@nhaCungCap", System.Data.SqlDbType.Int, 0).Value = phieuNhap.NhaCungCap;
            command.Parameters.Add("@ngayLap", System.Data.SqlDbType.DateTime, 0).Value = phieuNhap.NgayLap;
            command.Parameters.Add("@tongTien", System.Data.SqlDbType.Float, 0).Value = phieuNhap.TongTien;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = phieuNhap.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static List<PhieuNhapDTO> LayDanhSachPhieuNhap()
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
                    PhieuNhapDTO phieuNhap = new PhieuNhapDTO();
                    phieuNhap.MaPhieuNhap = reader.GetInt32(0);
                    phieuNhap.NhaCungCap = reader.GetInt32(1);
                    phieuNhap.NgayLap = reader.GetDateTime(2);
                    phieuNhap.TongTien = reader.GetDouble(3);
                    phieuNhap.TrangThai = reader.GetBoolean(4);
                    result.Add(phieuNhap);
                }
            }

            connection.Close();
            return result;
        }
    }
}
