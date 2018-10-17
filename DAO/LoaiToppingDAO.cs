using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class LoaiToppingDAO
    {
        public static List<LoaiToppingDTO> LayDanhSachLoaiTopping(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_loai_topping, ten_loai_topping, loai_mon FROM LoaiTopping WHERE loai_mon=@MaLoaiMon AND trang_thai=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@MaLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<LoaiToppingDTO> result = new List<LoaiToppingDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoaiToppingDTO loaiTopping = new LoaiToppingDTO();
                    loaiTopping.MaLoaiTopping = reader.GetInt32(0);
                    loaiTopping.TenLoaiTopping = reader.GetString(1);
                    loaiTopping.LoaiMon = reader.GetInt32(2);
                    result.Add(loaiTopping);
                }
            }

            connection.Close();
            return result;
        }
    }
}
