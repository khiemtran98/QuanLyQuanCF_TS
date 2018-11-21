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
        public static List<rptNhaCungCap_PhieuNhapDTO> DoiMaNhaCungCapThanhTenNhaCungCap(DateTime timeLine)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT PhieuNhap.ma_phieu_nhap,NhaCungCap.ten_nha_cung_cap, PhieuNhap.ngay_lap, PhieuNhap.tong_tien FROM NhaCungCap,PhieuNhap WHERE ma_nha_cung_cap = nha_cung_cap and DATEPART(YYYY, ngay_lap) = YEAR(@timeLine) AND DATEPART(MM, ngay_lap) = MONTH(@timeLine) AND DATEPART(DD, ngay_lap) = DAY(@timeLine)";
            
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@timeLine", System.Data.SqlDbType.DateTime, 0).Value = timeLine;

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
    }
}
