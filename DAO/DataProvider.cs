using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DataProvider
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=NHAILUUDAN\SQLEXPRESSSS;Initial Catalog=QuanLyQuanCF_TS;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        private static int taiKhoanDangNhap = -1;

        public static int TaiKhoanDangNhap { get => taiKhoanDangNhap; set => taiKhoanDangNhap = value; }
    }
}
