﻿using System;
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
        private static string connectionString = @"";

        public static List<MonDTO> layDanhSachMon(string timKiem = "")
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query;
            if (timKiem == string.Empty)
            {
                query = "SELECT mamon, tenmon, loaimon, hinh, giatien FROM Mon";
            }
            else
            {
                query = "SELECT mamon, tenmon, loaimon, hinh, giatien FROM Mon WHERE tenmon LIKE N'%'+@timkiem+'%'";
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
                    if (!reader.IsDBNull(0))
                    {
                        mon.MaMon = reader.GetInt32(0);
                    }
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
