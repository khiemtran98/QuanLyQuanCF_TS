using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class NguyenLieuDAO
    {
        public static List<NguyenLieuDTO> LayDanhSachNguyenLieu(string timKiem, bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();

            string query = "SELECT [ma_nguyen_lieu],[ten_nguyen_lieu],[so_luong],[don_vi_tinh],[trang_thai] FROM [NguyenLieu] WHERE 1=1";
            SqlCommand command = new SqlCommand();
            if (timKiem != string.Empty)
            {
                query += " AND ten_nguyen_lieu LIKE N'%'+@timKiem+'%'";
                command.Parameters.Add("@timKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }
            if (trangThai)
            {
                query += " AND trang_thai=1";
            }
            else
            {
                query += " AND trang_thai=0";
            }
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<NguyenLieuDTO> result = new List<NguyenLieuDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NguyenLieuDTO nguyenlieu = new NguyenLieuDTO();
                    nguyenlieu.MaNguyenLieu = reader.GetInt32(0);
                    nguyenlieu.TenNguyenLieu = reader.GetString(1);
                    nguyenlieu.SoLuong = reader.GetDouble(2);
                    nguyenlieu.DonViTinh = reader.GetString(3);
                    nguyenlieu.TrangThai = reader.GetBoolean(4);
                    result.Add(nguyenlieu);
                }
            }

            connection.Close();
            return result;
        }

        public static List<NguyenLieuDTO> LayDanhSachTatCaNguyenLieu()
        {
            SqlConnection connection = DataProvider.GetConnection();

            string query = "SELECT ma_nguyen_lieu, ten_nguyen_lieu, so_luong, don_vi_tinh, trang_thai FROM NguyenLieu";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<NguyenLieuDTO> result = new List<NguyenLieuDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NguyenLieuDTO nguyenlieu = new NguyenLieuDTO();
                    nguyenlieu.MaNguyenLieu = reader.GetInt32(0);
                    nguyenlieu.TenNguyenLieu = reader.GetString(1);
                    nguyenlieu.SoLuong = reader.GetDouble(2);
                    nguyenlieu.DonViTinh = reader.GetString(3);
                    nguyenlieu.TrangThai = reader.GetBoolean(4);
                    result.Add(nguyenlieu);
                }
            }

            connection.Close();
            return result;
        }

        public static bool TangSoLuongTonKho(CTPhieuNhapDTO ctpn)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE NguyenLieu SET so_luong=so_luong+@soLuong WHERE ma_nguyen_lieu=@maNguyenLieu";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maNguyenLieu", System.Data.SqlDbType.Int, 0).Value = ctpn.MaNguyenLieu;
            command.Parameters.Add("@soLuong", System.Data.SqlDbType.Float, 0).Value = ctpn.SoLuong;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool GiamSoLuongTonKho(CTPhieuNhapDTO ctpn)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE NguyenLieu SET so_luong=so_luong-@soLuong WHERE ma_nguyen_lieu=@maNguyenLieu";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maNguyenLieu", System.Data.SqlDbType.Int, 0).Value = ctpn.MaNguyenLieu;
            command.Parameters.Add("@soLuong", System.Data.SqlDbType.Float, 0).Value = ctpn.SoLuong;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool ThemNguyenLieu(NguyenLieuDTO nguyenlieu)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO NguyenLieu (ten_nguyen_lieu, so_luong, don_vi_tinh, trang_thai) VALUES (@tenNguyenLieu, @soLuong, @donViTinh, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@tenNguyenLieu", System.Data.SqlDbType.NVarChar, 255).Value = nguyenlieu.TenNguyenLieu;
            command.Parameters.Add("@soLuong", System.Data.SqlDbType.Float, 0).Value = nguyenlieu.SoLuong;
            command.Parameters.Add("@donViTinh", System.Data.SqlDbType.NVarChar, 255).Value = nguyenlieu.DonViTinh;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = nguyenlieu.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool XoaNguyenLieu(int maNguyenLieu)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE NguyenLieu SET trang_thai=0 WHERE ma_nguyen_lieu=@maNguyenLieu";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maNguyenLieu", System.Data.SqlDbType.Int, 0).Value = maNguyenLieu;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool SuaNguyenLieu(NguyenLieuDTO nguyenlieu)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE NguyenLieu SET ten_nguyen_lieu=@tenNguyenLieu, so_luong=@soLuong, don_vi_tinh=@donViTinh, trang_thai=@trangThai WHERE ma_nguyen_lieu=@maNguyenLieu";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maNguyenLieu", System.Data.SqlDbType.Int, 0).Value = nguyenlieu.MaNguyenLieu;
            command.Parameters.Add("@tenNguyenLieu", System.Data.SqlDbType.NVarChar, 255).Value = nguyenlieu.TenNguyenLieu;
            command.Parameters.Add("@soLuong", System.Data.SqlDbType.Float, 0).Value = nguyenlieu.SoLuong;
            command.Parameters.Add("@donViTinh", System.Data.SqlDbType.NVarChar, 255).Value = nguyenlieu.DonViTinh;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = nguyenlieu.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool KhoiPhucNguyenLieu(int maNguyenLieu)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE NguyenLieu SET trang_thai=1 WHERE ma_nguyen_lieu=@maNguyenLieu";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maNguyenLieu", System.Data.SqlDbType.Int, 0).Value = maNguyenLieu;

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
