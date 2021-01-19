using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach.DAO
{
    public class ChiTietKhachHangDAO
    {
        string connectionString =
                 ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public DataTable GetHDKH(string makh)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"select * from ViewChiTietHoaDonKhachHang Where MaKH=@makh";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@makh", makh);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
        public int GetTongTienKH(string makh)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"select sum(TongTien) from ViewChiTietHoaDonKhachHang Where MaKH=@makh";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@makh", makh);
            connection.Open();
            int sum = (int)cmd.ExecuteScalar();
            return sum;
        }
    }
}