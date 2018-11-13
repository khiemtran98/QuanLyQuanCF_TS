using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class NguyenLieuDAO
    {
        public static List<NguyenLieuDTO> LayDanhSachNguyenLieu(string timKiem ="")
        {
            SqlConnection connection = DataProvider.GetConnection();

            string query = "SELECT [ma_nguyen_lieu],[ten_nguyen_lieu],[so_luong],[don_vi],[trang_thai] FROM [NguyenLieu] WHERE 1=1";
            SqlCommand command = new SqlCommand();
            if (timKiem != string.Empty)
            {
                query += " AND ten_nguyen_lieu LIKE N'%'+@timKiem+'%'";
                command.Parameters.Add("@timKiem", System.Data.SqlDbType.NVarChar, 255).Value = timKiem;
            }
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<NguyenLieuDTO> result = new List<NguyenLieuDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NguyenLieuDTO nguyenlieu = new NguyenLieuDTO();
                    nguyenlieu.MaNguyenLieu = reader.GetInt32(0);
                    nguyenlieu.TenNguyenLieu = reader.GetString(1);
                    nguyenlieu.SoLuong = reader.GetInt32(2);
                    nguyenlieu.DonViTinh = reader.GetString(3);
                    nguyenlieu.TrangThai = reader.GetBoolean(4);
                    result.Add(nguyenlieu);
                }
            }

            connection.Close();
            return result;
        }

        //public static bool ThemNguyenLieu(NguyenLieuDTO nguyenlieu)
        //{

        //}

        //public static bool XoaNguyenLieu(int maNguyenLieu)
        //{

        //}

        //public static bool ThemNguyenLieu(NguyenLieuDTO nguyenlieu)
        //{

        //}
    }
}
