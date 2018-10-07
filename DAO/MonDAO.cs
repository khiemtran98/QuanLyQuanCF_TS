using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class MonDAO
    {
        public static List<MonDTO> LayDanhSachMon(string timKiem = "")
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query;
            if (timKiem == string.Empty)
            {
                query = "SELECT ma_mon, ten_mon, loai_mon, hinh, gia_tien FROM Mon WHERE trang_thai=1";
            }
            else
            {
                query = "SELECT ma_mon, ten_mon, loai_mon, hinh, gia_tien FROM Mon WHERE ten_mon LIKE N'%'+@timkiem+'%' and trang_thai=1";
            }
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@timkiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<MonDTO> result = new List<MonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MonDTO mon = new MonDTO();
                    mon.MaMon = reader.GetInt32(0);
                    mon.TenMon = reader.GetString(1);
                    mon.LoaiMon = reader.GetInt32(2);
                    mon.Hinh = reader.GetString(3);
                    mon.GiaTien = reader.GetDouble(4);
                    result.Add(mon);
                }
            }

            connection.Close();
            return result;
        }

        public static List<MonDTO> LayDanhSachMonTheoLoai(string tenLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT ma_mon, ten_mon, loai_mon, hinh, gia_tien FROM Mon WHERE loai_mon=(SELECT ma_loai_mon FROM LoaiMon WHERE ten_loai_mon LIKE @tenloaimon) and trang_thai=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@tenloaimon", System.Data.SqlDbType.NVarChar, 255).Value = tenLoaiMon;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<MonDTO> result = new List<MonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MonDTO mon = new MonDTO();
                    mon.MaMon = reader.GetInt32(0);
                    mon.TenMon = reader.GetString(1);
                    mon.LoaiMon = reader.GetInt32(2);
                    mon.Hinh = reader.GetString(3);
                    mon.GiaTien = reader.GetDouble(4);
                    result.Add(mon);
                }
            }

            connection.Close();
            return result;
        }
    }
}
