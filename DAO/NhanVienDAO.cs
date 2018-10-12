using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class NhanVienDAO
    {
        public static void LuuTaiKhoanDangNhap(int maNhanVien)
        {
            DataProvider.TaiKhoanDangNhap = maNhanVien;
        }

        public static int LayTaiKhoanDangNhap()
        {
            return DataProvider.TaiKhoanDangNhap;
        }

        public static List<NhanVienDTO> LayDanhSachNhanVien()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_nhan_vien, ho_ten FROM NhanVien";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<NhanVienDTO> result = new List<NhanVienDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NhanVienDTO nhanvien = new NhanVienDTO();
                    if (!reader.IsDBNull(0))
                    {
                        nhanvien.MaNhanVien = reader.GetInt32(0);
                        nhanvien.HoTen = reader.GetString(1);
                        result.Add(nhanvien);
                    }
                }
            }

            connection.Close();
            return result;
        }

        public static bool KiemTraDangNhap(int maNV, string matKhau)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT mat_khau FROM NhanVien WHERE ma_nhan_vien=@MaNhanVien";
            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@MaNhanVien", maNV);
            command.Parameters.Add(parameter);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            bool result = false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (matKhau == reader.GetString(0))
                    {
                        result = true;
                    }
                }
            }

            connection.Close();
            return result;
        }

        public static NhanVienDTO LayThongTinNhanVien(int maNV)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ho_ten, ngay_bat_dau, la_admin FROM NhanVien WHERE ma_nhan_vien=@MaNhanVien";
            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@MaNhanVien", maNV);
            command.Parameters.Add(parameter);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            NhanVienDTO result = new NhanVienDTO();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.HoTen = reader.GetString(0);
                    result.NgayBatDau = reader.GetDateTime(1);
                    result.LaAdmin = reader.GetBoolean(2);
                }
            }

            connection.Close();
            return result;
        }
    }
}
