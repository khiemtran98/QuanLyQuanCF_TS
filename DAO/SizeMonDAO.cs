using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class SizeMonDAO
    {
        public static List<SizeMonDTO> LaySizeMon(int maMon)
        {
            SqlConnection connection = DataProvider.GetConnection();

            string query = "SELECT size, ma_mon, gia_tien, trang_thai FROM SizeMon WHERE ma_mon=@maMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maMon", SqlDbType.Int, 0).Value = maMon;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<SizeMonDTO> result = new List<SizeMonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SizeMonDTO sizeMon = new SizeMonDTO();
                    sizeMon.Size = reader.GetString(0);
                    sizeMon.MaMon = reader.GetInt32(1);
                    sizeMon.GiaTien = reader.GetDouble(2);
                    sizeMon.TrangThai = reader.GetBoolean(3);
                    result.Add(sizeMon);
                }
            }

            connection.Close();
            return result;
        }

        public static double LayGiaTien(int maMon, string size)
        {
            SqlConnection connection = DataProvider.GetConnection();

            string query = "SELECT gia_tien FROM SizeMon WHERE ma_mon=@maMon AND size=@size";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maMon", SqlDbType.Int, 0).Value = maMon;
            command.Parameters.Add("@size", SqlDbType.NVarChar, 255).Value = size;

            connection.Open();
            double result = Convert.ToDouble(command.ExecuteScalar());

            connection.Close();
            return result;
        }
    }
}
