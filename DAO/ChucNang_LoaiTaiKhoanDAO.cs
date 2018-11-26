using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class ChucNang_LoaiTaiKhoanDAO
    {
        public static List<ChucNang_LoaiTaiKhoanDTO> LayDanhSachChucNang_LoaiTaiKhoanTheoMaLoaiTaiKhoan(int maLoaiTaiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_chuc_nang, ChucNang_LoaiTaiKhoan.ma_loai_tai_khoan FROM ChucNang_LoaiTaiKhoan, LoaiTaiKhoan WHERE LoaiTaiKhoan.ma_loai_tai_khoan=@maLoaiTaikhoan AND LoaiTaiKhoan.ma_loai_tai_khoan=ChucNang_LoaiTaiKhoan.ma_loai_tai_khoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTaikhoan", System.Data.SqlDbType.Int, 0).Value = maLoaiTaiKhoan;

            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ChucNang_LoaiTaiKhoanDTO> result = new List<ChucNang_LoaiTaiKhoanDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ChucNang_LoaiTaiKhoanDTO chucNang_LoaiTaiKhoan = new ChucNang_LoaiTaiKhoanDTO();
                    chucNang_LoaiTaiKhoan.MaChucNang = reader.GetInt32(0);
                    chucNang_LoaiTaiKhoan.MaLoaiTaiKhoan = reader.GetInt32(1);
                    result.Add(chucNang_LoaiTaiKhoan);
                }
            }
            command.Connection.Close();
            return result;
        }

        public static List<ChucNang_LoaiTaiKhoanDTO> LayDanhSachChucNang_LoaiTaiKhoanTheoMaTaiKhoan(int maTaiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_chuc_nang, ChucNang_LoaiTaiKhoan.ma_loai_tai_khoan FROM ChucNang_LoaiTaiKhoan, TaiKhoan WHERE TaiKhoan.ma_tai_khoan=@maTaiKhoan AND TaiKhoan.loai_tai_khoan=ChucNang_LoaiTaiKhoan.ma_loai_tai_khoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maTaiKhoan", System.Data.SqlDbType.Int, 0).Value = maTaiKhoan;

            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ChucNang_LoaiTaiKhoanDTO> result = new List<ChucNang_LoaiTaiKhoanDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ChucNang_LoaiTaiKhoanDTO chucNang_LoaiTaiKhoan = new ChucNang_LoaiTaiKhoanDTO();
                    chucNang_LoaiTaiKhoan.MaChucNang = reader.GetInt32(0);
                    chucNang_LoaiTaiKhoan.MaLoaiTaiKhoan = reader.GetInt32(1);
                    result.Add(chucNang_LoaiTaiKhoan);
                }
            }
            command.Connection.Close();
            return result;
        }

        public static bool ThemChucNang_LoaiTaiKhoan(ChucNang_LoaiTaiKhoanDTO chucNang_LoaiTaiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO ChucNang_LoaiTaiKhoan (ma_chuc_nang, ma_loai_tai_khoan) VALUES (@maChucNang, @maLoaiTaiKhoan)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maChucNang", System.Data.SqlDbType.Int, 0).Value = chucNang_LoaiTaiKhoan.MaChucNang;
            command.Parameters.Add("@maLoaiTaiKhoan", System.Data.SqlDbType.Int, 0).Value = chucNang_LoaiTaiKhoan.MaLoaiTaiKhoan;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool XoaChucNang_LoaiTaiKhoan(object maLoaiTaiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM ChucNang_LoaiTaiKhoan WHERE ma_loai_tai_khoan=@maLoaiTaiKhoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTaiKhoan", System.Data.SqlDbType.Int, 0).Value = maLoaiTaiKhoan;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            return true;
        }
    }
}
