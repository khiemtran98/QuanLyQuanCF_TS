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
            string connectionString = @"";
            return new SqlConnection(connectionString);
        }
    }
}
