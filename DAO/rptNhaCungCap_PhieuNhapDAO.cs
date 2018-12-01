using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class rptNhaCungCap_PhieuNhapDAO
    {
        public static List<rptNhaCungCap_PhieuNhapDTO> DoiMaNhaCungCapThanhTenNhaCungCap(DateTime timeStart,DateTime timeEnd)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT PhieuNhap.ma_phieu_nhap,NhaCungCap.ten_nha_cung_cap, PhieuNhap.ngay_lap, PhieuNhap.tong_tien FROM NhaCungCap,PhieuNhap WHERE ma_nha_cung_cap = nha_cung_cap and ngay_lap between @timeStart and @timeEnd";
            SqlCommand command = new SqlCommand();
            
            command.Parameters.Add("@timeStart", System.Data.SqlDbType.DateTime, 0).Value = timeStart;
            command.Parameters.Add("@timeEnd", System.Data.SqlDbType.DateTime, 0).Value = timeEnd;

            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<rptNhaCungCap_PhieuNhapDTO> result = new List<rptNhaCungCap_PhieuNhapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rptNhaCungCap_PhieuNhapDTO nhaCungCap_PhieuNhap = new rptNhaCungCap_PhieuNhapDTO();
                    nhaCungCap_PhieuNhap.MaPhieuNhap = reader.GetInt32(0);
                    nhaCungCap_PhieuNhap.TenNhaCungCap = reader.GetString(1);
                    nhaCungCap_PhieuNhap.NgayLap = reader.GetDateTime(2);
                    nhaCungCap_PhieuNhap.TongTien = reader.GetDouble(3);
                    result.Add(nhaCungCap_PhieuNhap);
                }
            }

            connection.Close();
            return result;
        }
        public static List<rptNhaCungCap_PhieuNhapDTO> DoiMaNhaCungCapThanhTenNhaCungCap()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT PhieuNhap.ma_phieu_nhap,NhaCungCap.ten_nha_cung_cap, PhieuNhap.ngay_lap, PhieuNhap.tong_tien FROM NhaCungCap,PhieuNhap WHERE ma_nha_cung_cap = nha_cung_cap";

            SqlCommand command = new SqlCommand();

            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<rptNhaCungCap_PhieuNhapDTO> result = new List<rptNhaCungCap_PhieuNhapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rptNhaCungCap_PhieuNhapDTO nhaCungCap_PhieuNhap = new rptNhaCungCap_PhieuNhapDTO();
                    nhaCungCap_PhieuNhap.MaPhieuNhap = reader.GetInt32(0);
                    nhaCungCap_PhieuNhap.TenNhaCungCap = reader.GetString(1);
                    nhaCungCap_PhieuNhap.NgayLap = reader.GetDateTime(2);
                    nhaCungCap_PhieuNhap.TongTien = reader.GetDouble(3);
                    result.Add(nhaCungCap_PhieuNhap);
                }
            }

            connection.Close();
            return result;
        }

        public static List<rptNhaCungCap_PhieuNhapDTO> DoiMaNhaCungCapThanhTenNhaCungCapMaPhieuNhapMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT PhieuNhap.ma_phieu_nhap,NhaCungCap.ten_nha_cung_cap, PhieuNhap.ngay_lap, PhieuNhap.tong_tien FROM NhaCungCap,PhieuNhap WHERE ma_nha_cung_cap = nha_cung_cap and PhieuNhap.ma_phieu_nhap = (SELECT MAX(ma_phieu_nhap) FROM PhieuNhap)";

            SqlCommand command = new SqlCommand();

            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<rptNhaCungCap_PhieuNhapDTO> result = new List<rptNhaCungCap_PhieuNhapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rptNhaCungCap_PhieuNhapDTO nhaCungCap_PhieuNhap = new rptNhaCungCap_PhieuNhapDTO();
                    nhaCungCap_PhieuNhap.MaPhieuNhap = reader.GetInt32(0);
                    nhaCungCap_PhieuNhap.TenNhaCungCap = reader.GetString(1);
                    nhaCungCap_PhieuNhap.NgayLap = reader.GetDateTime(2);
                    nhaCungCap_PhieuNhap.TongTien = reader.GetDouble(3);
                    result.Add(nhaCungCap_PhieuNhap);
                }
            }

            connection.Close();
            return result;
        }
    }
}
