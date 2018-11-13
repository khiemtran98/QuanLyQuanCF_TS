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
    }
}
