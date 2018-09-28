using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class LoaiMonDAO
    {
        private static string connectionString = @"";

        public static List<LoaiMonDTO> LayDanhSachLoaiMon()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT maloaimon, tenloaimon FROM LoaiMon";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<LoaiMonDTO> result = new List<LoaiMonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiMonDTO loaiMon = new LoaiMonDTO();
                    if (!reader.IsDBNull(0))
                    {
                        loaiMon.MaLoaiMon = reader.GetInt32(0);
                    }
                    try
                    {
                        loaiMon.TenLoaiMon = reader.GetString(1);
                    }
                    catch
                    {

                    }

                    result.Add(loaiMon);
                }
            }

            connection.Close();
            return result;
        }
    }
}
