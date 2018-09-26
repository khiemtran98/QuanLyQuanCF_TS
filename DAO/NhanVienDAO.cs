using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class NhanVienDAO
    {
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of ee82156... sửa lỗi vặt
        private static string connectionString = @"Data Source=DESKTOP-TQR1S60\SQLEXPRESS;Initial Catalog=QuanLyQuanCF_TS;Integrated Security=True";

>>>>>>> parent of ee82156... sửa lỗi vặt
        public static List<NhanVienDTO> layDanhSachNhanVien()
        {
            List<NhanVienDTO> result = new List<NhanVienDTO>();

            string connectionString = @"Data Source=DESKTOP-TQR1S60\SQLEXPRESS;Initial Catalog=QuanLyQuanCF_TS;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT manv, hoten FROM NhanVien";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NhanVienDTO nhanvien = new NhanVienDTO();
                    if (!reader.IsDBNull(0))
                    {
                        nhanvien.MaNV = reader.GetInt32(0);
                    }
                    nhanvien.HoTen = reader.GetString(1);

                    result.Add(nhanvien);
                }
            }
            connection.Close();

            return result;
        }

        public static bool DangNhap(int maNV, string matKhau)
        {
            bool result = false;

            string connectionString = @"Data Source=DESKTOP-TQR1S60\SQLEXPRESS;Initial Catalog=QuanLyQuanCF_TS;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@MaNV", maNV);

            string query = "SELECT matkhau FROM NhanVien WHERE manv=@MaNV";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(parameter);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    if (matKhau == reader.GetString(0))
                    {
                        result = true;
                    }
                }
            }
            connection.Close();

            return result;
        }
    }
}
