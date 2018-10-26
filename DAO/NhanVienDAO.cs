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

        public static List<NhanVienDTO> LayDanhSachNhanVien(string timKiem)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_nhan_vien, ho_ten, ngay_bat_dau, la_admin FROM NhanVien";
            SqlCommand command = new SqlCommand();
            if(timKiem != "")
            {
                query += " WHERE ho_ten LIKE N'%'+@timKiem+'%'";
                command.Parameters.Add("@timKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }

            command.CommandText = query;
            command.Connection = connection;

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
                        nhanvien.NgayBatDau = reader.GetDateTime(2);
                        nhanvien.LaAdmin = reader.GetBoolean(3);
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

        public static NhanVienDTO LayThongTinNhanVien(int maNV,string timKiem = "")
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

        public static bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO NhanVien (ho_ten, mat_khau, ngay_bat_dau, la_admin) VALUES (@hoTen, @matKhau, @ngayBatDau, @laAdmin)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@hoTen", System.Data.SqlDbType.NVarChar, 255).Value = nhanVien.HoTen;
            command.Parameters.Add("@matKhau", System.Data.SqlDbType.NVarChar, 255).Value = nhanVien.MatKhau;
            command.Parameters.Add("@ngayBatDau", System.Data.SqlDbType.DateTime, 0).Value = nhanVien.NgayBatDau;
            command.Parameters.Add("@laAdmin", System.Data.SqlDbType.Bit, 0).Value = nhanVien.LaAdmin;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool XoaNhanVien(int maNhanVien)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM NhanVien WHERE ma_nhan_vien=@maNhanVien";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maNhanVien", System.Data.SqlDbType.Int, 0).Value = maNhanVien;
            
            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool SuaThongTinNhanVien(NhanVienDTO nhanVien)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE NhanVien SET ho_ten=@hoTen, mat_khau=@matKhau, la_admin=@laAdmin WHERE ma_nhan_vien=@maNhanVien";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maNhanVien", System.Data.SqlDbType.Int, 0).Value = nhanVien.MaNhanVien;
            command.Parameters.Add("@hoTen", System.Data.SqlDbType.NVarChar, 255).Value = nhanVien.HoTen;
            command.Parameters.Add("@matKhau", System.Data.SqlDbType.NVarChar, 255).Value = nhanVien.MatKhau;
            command.Parameters.Add("@laAdmin", System.Data.SqlDbType.Bit, 0).Value = nhanVien.LaAdmin;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }
    }
}
