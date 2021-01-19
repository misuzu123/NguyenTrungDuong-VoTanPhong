using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class ChiTietHoaDonDAO
    {
        string connectionString =
              ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public DataTable GetCTHD(string mahd)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM ViewChiTietHoaDon WHERE MaHD = @mahd";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@mahd", mahd);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
    }
}