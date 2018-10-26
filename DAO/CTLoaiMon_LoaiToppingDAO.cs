using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
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

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool XoaLoaiMon_LoaiTopping(CTLoaiMon_LoaiToppingDTO loaiMon_LoaiTopping)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM CTLoaiMon_LoaiTopping WHERE ma_loai_mon=@maLoaiMon AND ma_loai_topping=@maLoaiTopping";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = loaiMon_LoaiTopping.MaLoaiMon;
            command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = loaiMon_LoaiTopping.MaLoaiTopping;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        //==>> Danh cho m Khiem
        //public static bool XoaLoaiMon_LoaiTopping(CTLoaiMon_LoaiToppingDTO loaiMon_LoaiTopping)
        //{
        //    SqlConnection connection = DataProvider.GetConnection();
        //    string query = "DELETE FROM CTLoaiMon_LoaiTopping WHERE ma_loai_mon=@maLoaiMon AND ma_loai_topping=@maLoaiTopping";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = loaiMon_LoaiTopping.MaLoaiMon;
        //    command.Parameters.Add("@maLoaiTopping", System.Data.SqlDbType.Int, 0).Value = loaiMon_LoaiTopping.MaLoaiTopping;

        //    connection.Open();

        //    int reader = command.ExecuteNonQuery();

        //    connection.Close();

        //    if (reader == 1)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
