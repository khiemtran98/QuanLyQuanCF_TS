using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class NguyenLieuDAO
    {
        public static List<NguyenLieuDTO> GetEntireMaterials()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_nguyen_lieu, ten_nguyen_lieu, so_luong, don_vi_tinh FROM NguyenLieu";
            SqlCommand command = new SqlCommand();
          
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<NguyenLieuDTO> result = new List<NguyenLieuDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NguyenLieuDTO obj = new NguyenLieuDTO();
                    obj.MaNguyenLieu = reader.GetInt32(0);
                    obj.TenNguyenLieu = reader.GetString(1);
                    obj.SoLuong = reader.GetInt32(2);
                    obj.DonVi = reader.GetString(3);
                    result.Add(obj);
                }
            }

            connection.Close();
            return result;
        }
    }
}
