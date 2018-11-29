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

        public static int LayMaMonMoiNhat()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT MAX(ma_mon) FROM Mon";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            return result is DBNull ? 0 : Convert.ToInt32(result);
        }

        public static List<MonDTO> LayDanhSachMon(int maLoaiMon, string timKiem, bool trangThai)
        {
            SqlConnection connection = DataProvider.GetConnection();

            string query = "SELECT ma_mon, ten_mon, loai_mon, LoaiMon.ten_loai_mon, hinh, gia_tien, Mon.trang_thai FROM Mon, LoaiMon WHERE LoaiMon.ma_loai_mon=Mon.loai_mon";
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
            else
            {
                query += " AND Mon.trang_thai=0 AND LoaiMon.trang_thai=1";
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
                    mon.TenLoaiMon = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        mon.Hinh = reader.GetString(4);
                    }
                    mon.GiaTien = reader.GetDouble(5);
                    mon.TrangThai = reader.GetBoolean(6);
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
            string query = "UPDATE Mon SET trang_thai=0 WHERE loai_mon=@maLoaiMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            return true;
        }

        public static bool ThemMon(MonDTO mon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "INSERT INTO Mon (ten_mon, loai_mon, hinh, gia_tien, trang_thai) VALUES (@tenMon, @loaiMon, @hinh, @giaTien, @trangThai)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@tenMon", System.Data.SqlDbType.NVarChar, 255).Value = mon.TenMon;
            command.Parameters.Add("@loaiMon", System.Data.SqlDbType.Int, 0).Value = mon.LoaiMon;
            command.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = mon.Hinh;
            command.Parameters.Add("@giaTien", System.Data.SqlDbType.Float, 0).Value = mon.GiaTien;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = mon.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool XoaMon(int maMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE Mon SET trang_thai=0 WHERE ma_mon=@maMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maMon", System.Data.SqlDbType.Int, 0).Value = maMon;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool SuaMon(MonDTO mon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE Mon SET ten_mon=@tenMon, loai_mon=@loaiMon, hinh=@hinh, gia_tien=@giaTien, trang_thai=@trangThai WHERE ma_mon=@maMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maMon", System.Data.SqlDbType.Int, 0).Value = mon.MaMon;
            command.Parameters.Add("@tenMon", System.Data.SqlDbType.NVarChar, 255).Value = mon.TenMon;
            command.Parameters.Add("@loaiMon", System.Data.SqlDbType.NVarChar, 255).Value = mon.LoaiMon;
            command.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = mon.Hinh;
            command.Parameters.Add("@giaTien", System.Data.SqlDbType.Float, 0).Value = mon.GiaTien;
            command.Parameters.Add("@trangThai", System.Data.SqlDbType.Bit, 0).Value = mon.TrangThai;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool KhoiPhucMon(int maMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE Mon SET trang_thai=1 WHERE ma_mon=@maMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maMon", System.Data.SqlDbType.Int, 0).Value = maMon;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            if (reader == 1)
            {
                return true;
            }
            return false;
        }

        public static bool KhoiPhucMonTheoLoai(int maLoaiMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "UPDATE Mon SET trang_thai=1 WHERE loai_mon=@maLoaiMon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@maLoaiMon", System.Data.SqlDbType.Int, 0).Value = maLoaiMon;

            connection.Open();

            int reader = command.ExecuteNonQuery();

            connection.Close();

            return true;
        }
    }
}
