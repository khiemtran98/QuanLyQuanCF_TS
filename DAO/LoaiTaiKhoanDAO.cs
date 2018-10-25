using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class LoaiTaiKhoanDAO
    {
        public static List<LoaiTaiKhoanDTO> LayDanhSachLoaiTaiKhoan(string timKiem)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_loai_tai_khoan, ten_loai_tai_khoan, trang_thai FROM LoaiTaiKhoan";
            SqlCommand command = new SqlCommand();
            if (timKiem != "")
            {
                query += " WHERE ten_loai_tai_khoan LIKE N'%'+@timKiem+'%'";
                command.Parameters.Add("@timKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }

            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<LoaiTaiKhoanDTO> result = new List<LoaiTaiKhoanDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiTaiKhoanDTO loaiTaiKhoan = new LoaiTaiKhoanDTO();
                    loaiTaiKhoan.MaLoaiTaiKhoan = reader.GetInt32(0);
                    loaiTaiKhoan.TenLoaiTaiKhoan = reader.GetString(1);
                    loaiTaiKhoan.TrangThai = reader.GetBoolean(2);
                    result.Add(loaiTaiKhoan);
                }
            }

            connection.Close();
            return result;
        }
    }
}
