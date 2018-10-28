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
        public static int LaySoLuongMonTheoLoai(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT COUNT(ma_mon) FROM Mon WHERE trang_thai=1";
            SqlCommand command = new SqlCommand();
            if (maLoaiMon != 0)
            {
                query += " AND loai_mon=@maLoaiMon";
                command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;
            }
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            int result = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();
            return result;
        }

        public static List<MonDTO> LayDanhSachMon(int maLoaiMon, string timKiem, bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();

            string query = "SELECT ma_mon, ten_mon, loai_mon, hinh, gia_tien, Mon.trang_thai FROM Mon, LoaiMon WHERE LoaiMon.ma_loai_mon=Mon.loai_mon";
            SqlCommand command = new SqlCommand();
            if (maLoaiMon != 0)
            {
                query += " AND Mon.loai_mon=@maLoaiMon";
                command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;
            }
            if (timKiem != string.Empty)
            {
                query += " AND ten_mon LIKE N'%'+@timKiem+'%'";
                command.Parameters.Add("@timKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }
            if (trangThai)
            {
                query += " AND Mon.trang_thai=1 AND LoaiMon.trang_thai=1";
            }
            command.CommandText = query;
            command.Connection = connection;

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
                    if (!reader.IsDBNull(3))
                    {
                        mon.Hinh = reader.GetString(3);
                    }
                    mon.GiaTien = reader.GetDouble(4);
                    result.Add(mon);
                }
            }

            connection.Close();
            return result;
        }

        public static bool KiemTraMonLaNuocUong(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT la_do_uong FROM LoaiMon WHERE ma_loai_mon=@maLoaiMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;

            connection.Open();
            bool result = Convert.ToBoolean(command.ExecuteScalar());

            connection.Close();
            return result;
        }

        public static bool XoaTatCaMonTheoLoai(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "DELETE FROM Mon WHERE loai_mon=@maLoaiMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            return true;
        }
    }
}
