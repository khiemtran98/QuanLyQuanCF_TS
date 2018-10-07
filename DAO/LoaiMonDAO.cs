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
        public static List<LoaiMonDTO> LayDanhSachLoaiMon()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_loai_mon, ten_loai_mon FROM LoaiMon";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<LoaiMonDTO> result = new List<LoaiMonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiMonDTO loaiMon = new LoaiMonDTO();
                    loaiMon.MaLoaiMon = reader.GetInt32(0);
                    loaiMon.TenLoaiMon = reader.GetString(1);
                    result.Add(loaiMon);
                }
            }

            connection.Close();
            return result;
        }
    }
}
