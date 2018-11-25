using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class rptMon_LoaiMonDAO
    {
        public static List<rptMon_LoaiMonDTO> DoiMaLoaiMonThanhLoaiMon()
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT Mon.ma_mon, Mon.ten_mon, LoaiMon.ten_loai_mon, Mon.gia_tien FROM Mon,LoaiMon WHERE Mon.loai_mon=LoaiMon.ma_loai_mon";

            SqlCommand command = new SqlCommand();

            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<rptMon_LoaiMonDTO> result = new List<rptMon_LoaiMonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rptMon_LoaiMonDTO mon_LoaiMonDTO = new rptMon_LoaiMonDTO();
                    mon_LoaiMonDTO.MaMon = reader.GetInt32(0);
                    mon_LoaiMonDTO.TenMon = reader.GetString(1);
                    mon_LoaiMonDTO.TenLoaiMon = reader.GetString(2);
                    mon_LoaiMonDTO.GiaTien = reader.GetDouble(3);
                    result.Add(mon_LoaiMonDTO);
                }
            }

            connection.Close();
            return result;
        }
        public static List<rptMon_LoaiMonDTO> DoiMaLoaiMonThanhLoaiMon(int maMon)
        {
            SqlConnection connection = DataProvider.GetConnection();
            string query = "SELECT Mon.ma_mon, Mon.ten_mon, LoaiMon.ten_loai_mon, Mon.gia_tien FROM Mon,LoaiMon WHERE Mon.loai_mon=LoaiMon.ma_loai_mon and Mon.ma_mon=@maMon";

            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@maMon", System.Data.SqlDbType.DateTime, 0).Value = maMon;

            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<rptMon_LoaiMonDTO> result = new List<rptMon_LoaiMonDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rptMon_LoaiMonDTO mon_LoaiMonDTO = new rptMon_LoaiMonDTO();
                    mon_LoaiMonDTO.MaMon = reader.GetInt32(0);
                    mon_LoaiMonDTO.TenMon = reader.GetString(1);
                    mon_LoaiMonDTO.TenLoaiMon = reader.GetString(2);
                    mon_LoaiMonDTO.GiaTien = reader.GetDouble(3);
                    result.Add(mon_LoaiMonDTO);
                }
            }

            connection.Close();
            return result;
        }
    }
}
