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
        public static int LayMaLoaiTaiKhoanMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT MAX(ma_loai_tai_khoan) FROM LoaiTaiKhoan";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            return result is DBNull ? 0 : Convert.ToInt32(result);
        }

        public static List<LoaiTaiKhoanDTO> LayDanhSachLoaiTaiKhoan(string timKiem, bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_loai_tai_khoan, ten_loai_tai_khoan, trang_thai FROM LoaiTaiKhoan WHERE 1=1";
            SqlCommand command = new SqlCommand();
            if (timKiem != "")
            {
                query += " AND ten_loai_tai_khoan LIKE N'%'+@timKiem+'%'";
                command.Parameters.Add("@timKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }
            if (trangThai)
            {
                query += " AND trang_thai=1";
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

        public static bool ThemLoaiTaiKhoan(LoaiTaiKhoanDTO loaiTaiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO LoaiTaiKhoan (ten_loai_tai_khoan, trang_thai) VALUES (@tenLoaiTaiKhoan, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@tenLoaiTaiKhoan", System.Data.SqlDbType.NVarChar, 255).Value = loaiTaiKhoan.TenLoaiTaiKhoan;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = loaiTaiKhoan.TrangThai;

            command.Connection.Open();
            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool XoaLoaiTaiKhoan(int maLoaiTaiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM LoaiTaiKhoan WHERE ma_loai_tai_khoan=@maLoaiTaiKhoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTaiKhoan", System.Data.SqlDbType.Int, 0).Value = maLoaiTaiKhoan;

            command.Connection.Open();
            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool SuaLoaiTaiKhoan(LoaiTaiKhoanDTO loaiTaiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE LoaiTaiKhoan SET ten_loai_tai_khoan=@tenLoaiTaiKhoan, trang_thai=@trangThai WHERE ma_loai_tai_khoan=@maLoaiTaiKhoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTaiKhoan", System.Data.SqlDbType.Int, 0).Value = loaiTaiKhoan.MaLoaiTaiKhoan;
            command.Parameters.Add("@tenLoaiTaiKhoan", System.Data.SqlDbType.NVarChar, 255).Value = loaiTaiKhoan.TenLoaiTaiKhoan;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = loaiTaiKhoan.TrangThai;

            command.Connection.Open();
            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }
    }
}
