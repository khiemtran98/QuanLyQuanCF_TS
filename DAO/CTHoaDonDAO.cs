using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class CTHoaDonDAO
    {
        public static int LayMaCTHoaDonMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT MAX(ma_cthd) FROM CTHoaDon";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            return result is DBNull ? 0 : Convert.ToInt32(result);
        }

        public static bool LuuCTHoaDon(CTHoaDonDTO CTHoaDon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO CTHoaDon (hoa_don, mon, so_luong, don_gia, ghi_chu) VALUES (@maHoaDon, @maMon, @soLuong, @donGia, @ghiChu)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maHoaDon", System.Data.SqlDbType.Int, 0).Value = CTHoaDon.MaHoaDon;
            command.Parameters.Add("@maMon", System.Data.SqlDbType.Int, 0).Value = CTHoaDon.MaMon;
            command.Parameters.Add("@soLuong", System.Data.SqlDbType.Int, 0).Value = CTHoaDon.SoLuong;
            command.Parameters.Add("@donGia", System.Data.SqlDbType.Float, 0).Value = CTHoaDon.DonGia;
            command.Parameters.Add("@ghiChu", System.Data.SqlDbType.NVarChar, 255).Value = CTHoaDon.GhiChu;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static List<CTHoaDonDTO> LayDanhSachCTHD(int maHoaDon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_cthd, hoa_don, mon, so_luong, don_gia, ghi_chu FROM CTHoaDon WHERE hoa_don=@maHoaDon";
           
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@maHoaDon", System.Data.SqlDbType.NVarChar, 255).Value = maHoaDon;
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CTHoaDonDTO> result = new List<CTHoaDonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CTHoaDonDTO cthd = new CTHoaDonDTO();
                    cthd.MaCTHD = reader.GetInt32(0);
                    cthd.MaHoaDon = reader.GetInt32(1);
                    cthd.MaMon = reader.GetInt32(2);
                    cthd.SoLuong = reader.GetInt32(3);
                    cthd.DonGia = reader.GetDouble(4);
                    cthd.GhiChu = reader.GetString(5);
                    result.Add(cthd);
                }
            }

            connection.Close();
            return result;
        }

        public static List<CTHoaDonDTO> LayDanhSachCTHD_Report(int maHD)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_cthd, hoa_don, mon, so_luong, don_gia, ghi_chu FROM CTHoaDon WHERE hoa_don=@maHD";

            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@maHD", System.Data.SqlDbType.NVarChar, 255).Value = maHD;
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CTHoaDonDTO> result = new List<CTHoaDonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CTHoaDonDTO cthd = new CTHoaDonDTO();
                    cthd.MaCTHD = reader.GetInt32(0);
                    cthd.MaHoaDon = reader.GetInt32(1);
                    cthd.MaMon = reader.GetInt32(2);
                    cthd.SoLuong = reader.GetInt32(3);
                    cthd.DonGia = reader.GetDouble(4);
                    cthd.GhiChu = reader.GetString(5);
                    result.Add(cthd);
                }
            }

            connection.Close();
            return result;
        }
    }
}
