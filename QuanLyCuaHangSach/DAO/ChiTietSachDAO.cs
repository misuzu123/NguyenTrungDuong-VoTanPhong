using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangSach
{
    public class ChiTietSachDAO
    {
        string connectionString =
           ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public DataTable GetSach(string masach)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM ViewSach WHERE MaSach = @masach";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@masach", masach);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
    }
}