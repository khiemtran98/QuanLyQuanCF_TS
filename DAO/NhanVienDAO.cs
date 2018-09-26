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
        private static string connectionString = @"Data Source=DESKTOP-TQR1S60\SQLEXPRESS;Initial Catalog=QuanLyQuanCF_TS;Integrated Security=True";

        public static List<NhanVienDTO> layDanhSachNhanVien()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT manv, hoten FROM NhanVien";
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
                        nhanvien.MaNV = reader.GetInt32(0);
                    }
                    try
                    {
                        nhanvien.HoTen = reader.GetString(1);
                    }
                    catch
                    {
                        nhanvien.HoTen = "unknown";
                    }

                    result.Add(nhanvien);
                }
            }

            connection.Close();
            return result;
        }

        public static bool DangNhap(int maNV, string matKhau)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT matkhau FROM NhanVien WHERE manv=@MaNV";
            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@MaNV", maNV);
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

        public static NhanVienDTO layThongTinNhanVien(int maNV)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT hoten, ngaysinh, phai, sdt, ngaybatdau, diachi, ca, laAdmin FROM NhanVien WHERE manv=@MaNV";
            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@MaNV", maNV);
            command.Parameters.Add(parameter);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            NhanVienDTO result = new NhanVienDTO();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        result.HoTen = reader.GetString(0);
                    }
                    catch
                    {
                        result.HoTen = "unknown";
                    }
                    try
                    {
                        result.NgaySinh = reader.GetDateTime(1);
                    }
                    catch
                    {
                        result.NgaySinh = DateTime.Now;
                    }
                    try
                    {
                        result.Phai = reader.GetInt32(2);
                    }
                    catch
                    {
                        result.Phai = 0;
                    }
                    try
                    {
                        result.SDT = reader.GetString(3);
                    }
                    catch
                    {
                        result.SDT = "unknown";
                    }
                    try
                    {
                        result.NgayBatDau = reader.GetDateTime(4);
                    }
                    catch
                    {
                        result.NgayBatDau = DateTime.Now;
                    }
                    try
                    {
                        result.DiaChi = reader.GetString(5);
                    }
                    catch
                    {
                        result.DiaChi = "unknown";
                    }
                    try
                    {
                        result.Ca = reader.GetInt32(6);
                    }
                    catch
                    {
                        result.Ca = 0;
                    }
                    try
                    {
                        result.LaAdmin = reader.GetBoolean(7);
                    }
                    catch
                    {
                        result.LaAdmin = false;
                    }
                }
            }

            connection.Close();
            return result;
        }
    }
}
