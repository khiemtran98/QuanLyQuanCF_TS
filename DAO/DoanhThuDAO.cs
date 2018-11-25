using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class DoanhThuDAO
    {
        //    public static DoanhThuDTO LayDoanhThuTheoNam(DateTime time)
        //    {
        //        DoanhThuDTO result = new DoanhThuDTO();
        //        result.ThoiGian = time.Year.ToString();
        //        SqlConnection connection = DataProvider.GetConnection();
        //        string query = "SELECT tong_tien, trang_thai FROM HoaDon WHERE DATEPART(YYYY, ngay_lap) = YEAR(@timeLine) AND DATEPART(MM, ngay_lap) = MONTH(@timeLine) AND DATEPART(DD, ngay_lap) = DAY(@timeLine)";

        //        SqlCommand command = new SqlCommand();
        //        command.Parameters.Add("@timeLine", System.Data.SqlDbType.DateTime, 0).Value = timeLine;
        //        command.CommandText = query;
        //        command.Connection = connection;

        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();


        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                HoaDonDTO hd = new HoaDonDTO();
        //                hd.MaHoaDon = reader.GetInt32(0);
        //                hd.NhanVienLap = reader.GetInt32(1);
        //                hd.NgayLap = reader.GetDateTime(2);
        //                hd.TongTien = reader.GetDouble(3);
        //                hd.TrangThai = reader.GetBoolean(4);
        //                result.Add(hd);
        //            }
        //        }

        //        connection.Close();
        //        return result;

        //    }
        //}
    }
}
