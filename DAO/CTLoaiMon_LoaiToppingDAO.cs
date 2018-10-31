using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class CTLoaiMon_LoaiToppingDAO
    {
       public static bool ThemLoaiMon_LoaiTopping(CTLoaiMon_LoaiToppingDTO loaiMon_LoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO CTLoaiMon_LoaiTopping (ma_loai_mon, ma_loai_topping) VALUES (@maLoaiMon, @maLoaiTopping)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = loaiMon_LoaiTopping.MaLoaiMon;
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = loaiMon_LoaiTopping.MaLoaiTopping;
           
            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader > 0)
            {
                return true;
            }
            return false;
        }

        public static bool XoaLoaiMon_LoaiToppingTheoLoaiMon(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM CTLoaiMon_LoaiTopping WHERE ma_loai_mon=@maLoaiMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            return true;
        }

        public static bool XoaLoaiMon_LoaiToppingTheoLoaiTopping(int maLoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM CTLoaiMon_LoaiTopping WHERE ma_loai_topping=@maLoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = maLoaiTopping;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            return true;
        }
    }
}
