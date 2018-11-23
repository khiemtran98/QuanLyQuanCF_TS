using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public static class rptPhieuNhap_CTPhieuNhapDAO
    {
        public static List<rptPhieuNhap_CTPhieuNhapDTO> DoiMaNguyenLieuThanhTenNguyenLieu(int maPhieuNhap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT NguyenLieu.ten_nguyen_lieu, CTPhieuNhap.so_luong, CTPhieuNhap.don_vi_tinh, CTPhieuNhap.don_gia FROM CTPhieuNhap,NguyenLieu WHERE CTPhieuNhap.ma_nguyen_lieu=NguyenLieu.ma_nguyen_lieu and CTPhieuNhap.ma_phieu_nhap=@maPhieuNhap";

            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@maPhieuNhap", System.Data.SqlDbType.Int, 0).Value = maPhieuNhap;
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<rptPhieuNhap_CTPhieuNhapDTO> result = new List<rptPhieuNhap_CTPhieuNhapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rptPhieuNhap_CTPhieuNhapDTO phieuNhap_CTPhieuNhapDTO = new rptPhieuNhap_CTPhieuNhapDTO();
                    phieuNhap_CTPhieuNhapDTO.TenNguyenLieu = reader.GetString(0);
                    phieuNhap_CTPhieuNhapDTO.SoLuong = reader.GetInt32(1);
                    phieuNhap_CTPhieuNhapDTO.DonViTinh = reader.GetString(2);
                    phieuNhap_CTPhieuNhapDTO.DonGia = reader.GetDouble(3);
                    result.Add(phieuNhap_CTPhieuNhapDTO);
                }
            }

            connection.Close();
            return result;
        }
    }
}
