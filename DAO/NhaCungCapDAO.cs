using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class NhaCungCapDAO
    {
        public static List<NhaCungCapDTO> LayDanhSachNhaCungCap(string timKiem, bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_nha_cung_cap, ten_nha_cung_cap, trang_thai FROM NhaCungCap WHERE 1=1";
            SqlCommand command = new SqlCommand();
            if (timKiem != "")
            {
                query += " AND ten_nha_cung_cap LIKE N'%'+@timKiem+'%'";
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

            List<NhaCungCapDTO> result = new List<NhaCungCapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NhaCungCapDTO nhaCungCap = new NhaCungCapDTO();
                    nhaCungCap.MaNhaCungCap = reader.GetInt32(0);
                    nhaCungCap.TenNhaCungCap = reader.GetString(1);
                    nhaCungCap.TrangThai = reader.GetBoolean(2);
                    result.Add(nhaCungCap);
                }
            }

            connection.Close();
            return result;
        }

        public static bool ThemNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO NhaCungCap (ten_nha_cung_cap, trang_thai) VALUES (@tenNhaCungCap, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@tenNhaCungCap", System.Data.SqlDbType.NVarChar, 255).Value = nhaCungCap.TenNhaCungCap;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = nhaCungCap.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool XoaNhaCungCap(int maNhaCungCap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE NhaCungCap SET trang_thai=0 WHERE ma_nha_cung_cap=@maNhaCungCap";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@maNhaCungCap", System.Data.SqlDbType.NVarChar, 255).Value = maNhaCungCap;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool SuaNhaCungCap(NhaCungCapDTO nhaCungCap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE NhaCungCap SET ten_nha_cung_cap=@tenNhaCungCap, trang_thai=@trangThai WHERE ma_nha_cung_cap=@maNhaCungCap";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maNhaCungCap", System.Data.SqlDbType.Int, 0).Value = nhaCungCap.MaNhaCungCap;
            command.Parameters.Add("@tenNhaCungCap", System.Data.SqlDbType.NVarChar, 255).Value = nhaCungCap.TenNhaCungCap;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = nhaCungCap.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool KhoiPhucLoaiMon(int maNhaCungCap)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE NhaCungCap SET trang_thai=1 WHERE ma_nha_cung_cap=@maNhaCungCap";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@maNhaCungCap", System.Data.SqlDbType.NVarChar, 255).Value = maNhaCungCap;

            connection.Open();

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
