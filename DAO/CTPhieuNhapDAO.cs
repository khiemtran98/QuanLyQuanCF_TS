using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class CTPhieuNhapDAO
    {
        // Lấy chi tiết phiếu nhập theo mã phiếu nhập
        public static List<CTPhieuNhapDTO> GetListDetailMaterials(int maPhieuNhap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_phieu_nhap, ma_nguyen_lieu, so_luong, don_vi_tinh, don_gia FROM CTPhieuNhap WHERE ma_phieu_nhap=@maPhieuNhap";

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
                    CTPhieuNhapDTO obj = new CTPhieuNhapDTO();
                    obj.MaPhieuNhap = reader.GetInt32(0);
                    obj.MaNguyenLieu = reader.GetInt32(1);
                    obj.SoLuong = reader.GetInt32(2);
                    obj.DonVi = reader.GetString(3);
                    obj.DonGia = reader.GetDouble(4);
                    result.Add(obj);
                }
            }

            connection.Close();
            return result;
        }
    }
}
