using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class NhaCungCapDAO
    {
        public static List<NhaCungCapDTO> GetEntireProvider()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_nha_cung_cap, ten_nha_cung_cap FROM NhaCungCap";
            SqlCommand command = new SqlCommand();
      
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<NhaCungCapDTO> result = new List<NhaCungCapDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NhaCungCapDTO obj = new NhaCungCapDTO();
                    obj.MaNhaCungCap = reader.GetInt32(0);
                    obj.TenNhaCungCap = reader.GetString(1);
                    result.Add(obj);
                }
            }

            connection.Close();
            return result;
        }
    }
}
