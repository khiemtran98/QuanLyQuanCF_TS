using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class CTPhieuNhapDAO
    {
        public static bool LuuCTPhieuNhap(CTPhieuNhapDTO ctpn)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO CTPhieuNhap (ma_phieu_nhap, ma_nguyen_lieu, so_luong, don_vi_tinh, don_gia, ghi_chu) VALUES (@maPhieuNhap, @maNguyenLieu, @soLuong, @donViTinh, @donGia, @ghiChu)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maPhieuNhap", System.Data.SqlDbType.Int, 0).Value = ctpn.MaPhieuNhap;
            command.Parameters.Add("@maNguyenLieu", System.Data.SqlDbType.Int, 0).Value = ctpn.MaNguyenLieu;
            command.Parameters.Add("@soLuong", System.Data.SqlDbType.Float, 0).Value = ctpn.SoLuong;
            command.Parameters.Add("@donViTinh", System.Data.SqlDbType.NVarChar, 255).Value = ctpn.DonViTinh;
            command.Parameters.Add("@donGia", System.Data.SqlDbType.Float, 0).Value = ctpn.DonGia;
            command.Parameters.Add("@ghiChu", System.Data.SqlDbType.NVarChar, 255).Value = ctpn.GhiChu;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static List<CTPhieuNhapDTO> LayDanhSachCTPhieuNhap(int maPhieuNhap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_phieu_nhap, ma_nguyen_lieu, so_luong, don_gia, don_vi_tinh, ghi_chu FROM CTPhieuNhap WHERE ma_phieu_nhap=@maPhieuNhap";

            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@maPhieuNhap", System.Data.SqlDbType.NVarChar, 255).Value = maPhieuNhap;
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CTPhieuNhapDTO> result = new List<CTPhieuNhapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CTPhieuNhapDTO ctpn = new CTPhieuNhapDTO();
                    ctpn.MaPhieuNhap = reader.GetInt32(0);
                    ctpn.MaNguyenLieu = reader.GetInt32(1);
                    ctpn.SoLuong = reader.GetDouble(2);
                    ctpn.DonGia = reader.GetDouble(3);
                    ctpn.DonViTinh = reader.GetString(4);
                    ctpn.GhiChu = reader.GetString(5);
                    result.Add(ctpn);
                }
            }

            connection.Close();
            return result;
        }
    }
}
