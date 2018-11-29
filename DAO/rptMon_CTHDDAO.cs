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
            string query = "SELECT CTHoaDon.ma_cthd, Mon.ten_mon, CTHoaDon.don_gia, CTHoaDon.so_luong, CTHoaDon.ghi_chu FROM Mon,CTHoaDon WHERE Mon.ma_mon=CTHoaDon.mon and CTHoaDon.hoa_don=@maHD";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maHD", System.Data.SqlDbType.Int, 0).Value = maHD;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<rptMon_CTHDDTO> result = new List<rptMon_CTHDDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rptMon_CTHDDTO mon_CTHDDTO = new rptMon_CTHDDTO();
                    mon_CTHDDTO.MaCTHD = reader.GetInt32(0);
                    mon_CTHDDTO.TenMon = reader.GetString(1);
                    mon_CTHDDTO.DonGia = reader.GetDouble(2);
                    mon_CTHDDTO.SoLuong = reader.GetInt32(3);
                    mon_CTHDDTO.GhiChu = reader.GetString(4);
                    result.Add(mon_CTHDDTO);
                }
            }

            reader.Close();

            query = "SELECT ma_cthd, Topping.ten_topping, so_luong, don_gia, ghi_chu FROM CTHoaDon_Topping, Topping WHERE ma_cthd = @maCTHD and CTHoaDon_Topping.ma_topping = Topping.ma_topping";
            command = new SqlCommand(query, connection);

            int soLuongMon = result.Count;
            int index = 1;
            bool isFirstRow = true;
            List<rptMon_CTHDDTO> lsTemp = new List<rptMon_CTHDDTO>();
            foreach (rptMon_CTHDDTO cthd in result)
            {
                lsTemp.Add(cthd);
            }

            for (int i = 0; i < soLuongMon; i++)
            {
                if (!isFirstRow)
                {
                    index++;
                }
                command.Parameters.Add("@maCTHD", System.Data.SqlDbType.Int, 0).Value = lsTemp[i].MaCTHD;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rptMon_CTHDDTO mon_CTHDDTO = new rptMon_CTHDDTO();
                        mon_CTHDDTO.MaCTHD = reader.GetInt32(0);
                        mon_CTHDDTO.TenMon = reader.GetString(1);
                        mon_CTHDDTO.SoLuong = reader.GetInt32(2);
                        mon_CTHDDTO.DonGia = reader.GetDouble(3);
                        mon_CTHDDTO.GhiChu = reader.GetString(4);
                        result.Insert(index, mon_CTHDDTO);
                        index++;
                    }
                }
                isFirstRow = false;
                reader.Close();
                command.Parameters.Clear();
            }

            connection.Close();
            return result;
        }
    }
}
