using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class SachTheoTheLoaiDAO
    {
        string connectionString =
           ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public DataTable GetAllSachByMaLoai(string maloai)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM ViewSach WHERE MaLoai = @maloai";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@maloai", maloai);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
        public int GetSoLuongSachTheoMaLoai(string maloai)
        {
            string sql = @"SELECT COUNT(*)
                            FROM Sach
                            WHERE MaLoai = @maloai";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maloai", maloai);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count;
            }
        }
    }
}