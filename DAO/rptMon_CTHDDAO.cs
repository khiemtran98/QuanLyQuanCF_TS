using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public static class rptMon_CTHDDAO
    {
        public static List<rptMon_CTHDDTO> DoiMaMonThanhTenMon(int maHD)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT Mon.ten_mon, CTHoaDon.don_gia, CTHoaDon.so_luong, CTHoaDon.ghi_chu FROM Mon,CTHoaDon WHERE Mon.ma_mon=CTHoaDon.mon and CTHoaDon.hoa_don=@maHD";

            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@maHD", System.Data.SqlDbType.Int, 0).Value = maHD;
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<rptMon_CTHDDTO> result = new List<rptMon_CTHDDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rptMon_CTHDDTO mon_CTHDDTO = new rptMon_CTHDDTO();
                    mon_CTHDDTO.TenMon = reader.GetString(0);
                    mon_CTHDDTO.DonGia = reader.GetDouble(1);
                    mon_CTHDDTO.SoLuong = reader.GetInt32(2);
                    mon_CTHDDTO.GhiChu = reader.GetString(3);
                    result.Add(mon_CTHDDTO);
                }
            }

            connection.Close();
            return result;
        }
    }
}
