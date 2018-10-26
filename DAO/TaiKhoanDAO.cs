﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class TaiKhoanDAO
    {
        public static void LuuTaiKhoanDangNhap(int maTaiKhoan)
        {
            DataProvider.TaiKhoanDangNhap = maTaiKhoan;
        }

        public static int LayTaiKhoanDangNhap()
        {
            return DataProvider.TaiKhoanDangNhap;
        }

        public static List<TaiKhoanDTO> LayDanhSachTaiKhoan(string timKiem)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_tai_khoan, ho_ten, ngay_bat_dau, loai_tai_khoan, hinh, trang_thai FROM TaiKhoan";
            SqlCommand command = new SqlCommand();
            if (timKiem != "")
            {
                query += " WHERE ho_ten LIKE N'%'+@timKiem+'%'";
                command.Parameters.Add("@timKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }

            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<TaiKhoanDTO> result = new List<TaiKhoanDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
                    taiKhoan.MaTaiKhoan = reader.GetInt32(0);
                    taiKhoan.HoTen = reader.GetString(1);
                    taiKhoan.NgayBatDau = reader.GetDateTime(2);
                    taiKhoan.LoaiTaiKhoan = reader.GetInt32(3);
                    if (!reader.IsDBNull(4))
                    {
                        taiKhoan.Hinh = reader.GetString(4);
                    }
                    taiKhoan.TrangThai = reader.GetBoolean(5);
                    result.Add(taiKhoan);
                }
            }

            connection.Close();
            return result;
        }

        public static bool KiemTraDangNhap(int maTaiKhoan, string matKhau)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT mat_khau FROM TaiKhoan WHERE ma_tai_khoan=@maTaiKhoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maTaiKhoan", System.Data.SqlDbType.Int, 0).Value = maTaiKhoan;

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

        public static TaiKhoanDTO LayThongTinTaiKhoan(int maTaiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ho_ten, ngay_bat_dau, loai_tai_khoan, hinh, trang_thai FROM TaiKhoan WHERE ma_tai_khoan=@maTaiKhoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maTaiKhoan", SqlDbType.Int, 0).Value = maTaiKhoan;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            TaiKhoanDTO result = new TaiKhoanDTO();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.HoTen = reader.GetString(0);
                    result.NgayBatDau = reader.GetDateTime(1);
                    result.LoaiTaiKhoan = reader.GetInt32(2);
                    if (!reader.IsDBNull(3))
                    {
                        result.Hinh = reader.GetString(3);
                    }
                    result.TrangThai = reader.GetBoolean(4);
                }
            }

            connection.Close();
            return result;
        }

        public static string LayTenLoaiTaiKhoan(int maLoaiTaikhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ten_loai_tai_khoan FROM LoaiTaiKhoan WHERE ma_loai_tai_khoan=@maLoaiTaikhoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTaiKhoan", SqlDbType.Int, 0).Value = maLoaiTaikhoan;

            connection.Open();
            string result = command.ExecuteScalar().ToString();

            connection.Close();
            return result;
        }

        public static bool ThemTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO TaiKhoan (ho_ten, mat_khau, ngay_bat_dau, loai_tai_khoan, hinh, trang_thai) VALUES (@hoTen, @matKhau, @ngayBatDau, @loaiTaiKhoan, @hinh, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@hoTen", System.Data.SqlDbType.NVarChar, 255).Value = taiKhoan.HoTen;
            command.Parameters.Add("@matKhau", System.Data.SqlDbType.NVarChar, 255).Value = taiKhoan.MatKhau;
            command.Parameters.Add("@ngayBatDau", System.Data.SqlDbType.DateTime, 0).Value = taiKhoan.NgayBatDau;
            command.Parameters.Add("@loaiTaiKhoan", System.Data.SqlDbType.Int, 0).Value = taiKhoan.LoaiTaiKhoan;
            command.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = taiKhoan.Hinh;
            command.Parameters.Add("@TrangThai", System.Data.SqlDbType.Bit, 0).Value = taiKhoan.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool XoaTaiKhoan(int maTaiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM TaiKhoan WHERE ma_tai_khoan=@maTaiKhoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maTaiKhoan", System.Data.SqlDbType.Int, 0).Value = maTaiKhoan;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool SuaTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE TaiKhoan SET ho_ten=@hoTen, mat_khau=@matKhau, loai_tai_khoan=@loaiTaiKhoan, hinh=@hinh, trang_thai=@trangThai WHERE ma_tai_khoan=@maTaiKhoan";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maTaiKhoan", System.Data.SqlDbType.Int, 0).Value = taiKhoan.MaTaiKhoan;
            command.Parameters.Add("@hoTen", System.Data.SqlDbType.NVarChar, 255).Value = taiKhoan.HoTen;
            command.Parameters.Add("@matKhau", System.Data.SqlDbType.NVarChar, 255).Value = taiKhoan.MatKhau;
            command.Parameters.Add("@loaiTaiKhoan", System.Data.SqlDbType.Bit, 0).Value = taiKhoan.LoaiTaiKhoan;
            command.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = taiKhoan.Hinh;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = taiKhoan.TrangThai;

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