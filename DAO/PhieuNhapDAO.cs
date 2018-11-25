using System;
using System.Collections.Generic;
using System.Data;
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

        public static bool XoaPhieuNhap(int maPhieuNhap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE PhieuNhap SET trang_thai=0 WHERE ma_phieu_nhap=@maPhieuNhap";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maPhieuNhap", System.Data.SqlDbType.Int, 0).Value = maPhieuNhap;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool KhoiPhucPhieuNhap(int maPhieuNhap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE PhieuNhap SET trang_thai=1 WHERE ma_phieu_nhap=@maPhieuNhap";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maPhieuNhap", System.Data.SqlDbType.Int, 0).Value = maPhieuNhap;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static List<PhieuNhapDTO> LayDanhSachPhieuNhap(bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_phieu_nhap, nha_cung_cap, ngay_lap, tong_tien, trang_thai FROM PhieuNhap WHERE 1=1";
            SqlCommand command = new SqlCommand();

            if (trangThai)
            {
                query += "AND trang_thai=1";
            }
            else
            {
                query += "AND trang_thai=0";
            }

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

        public static List<PhieuNhapDTO> LayDanhSachPhieuNhapTheoNgay(DateTime ngayNhap, bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_phieu_nhap, nha_cung_cap, ngay_lap, tong_tien, trang_thai FROM PhieuNhap WHERE DAY(ngay_lap)=@ngay AND MONTH(ngay_lap)=@thang AND YEAR(ngay_lap)=@nam";
            if (trangThai)
            {
                query += " AND trang_thai=1";
            }
            else
            {
                query += " AND trang_thai=0";
            }
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@ngay", System.Data.SqlDbType.Int, 0).Value = ngayNhap.Day;
            command.Parameters.Add("@thang", System.Data.SqlDbType.Int, 0).Value = ngayNhap.Month;
            command.Parameters.Add("@nam", System.Data.SqlDbType.Int, 0).Value = ngayNhap.Year;
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

        public static double LayDoanhSoPhieuNhapTheoThang(int thang)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT SUM(tong_tien) FROM PhieuNhap WHERE trang_thai=1 AND MONTH(ngay_lap)=@thang AND YEAR(ngay_lap)=@nam";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@thang", SqlDbType.Int, 0).Value = thang;
            command.Parameters.Add("@nam", SqlDbType.Int, 0).Value = DateTime.Now.Year;

            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            return result is DBNull ? 0 : Convert.ToDouble(result);
        }
    }
}
