using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class TheLoaiDAO
    {
        string connectionString =
           ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public bool CheckMaLoai(string maLoai)
        {
            string sql = @"SELECT COUNT(*)
        FROM TheLoai
        WHERE MaLoai = @maloai";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maloai", maLoai);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
                //if (count >= 1) return true;
                //else return false;
            }
        }
        public bool Insert(TheLoai theLoai)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO
        TheLoai(MaLoai,TenLoai)
        VALUES (@maloai,@tenloai)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@maloai", theLoai.MaLoai);
                cmd.Parameters.AddWithValue("@tenloai", theLoai.TenLoai);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public DataTable GetAllTheLoai()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM TheLoai", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public TheLoai GetTheLoaiByMaLoai(string maloai)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM TheLoai WHERE MaLoai = @maloai";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@maloai", maloai);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                     TheLoai theLoai = new TheLoai
                    {
                        // Lấy giá trị theo tên cột trong CSDL,
                        MaLoai = (string)reader["MaLoai"],
                        TenLoai = (string)reader["TenLoai"]
                    };
                    return theLoai;
                }
            }
            return null;
        }
        public bool DeleteTheLoai(String maloai)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"delete from TheLoai WHERE MaLoai=@maloai";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@maloai", maloai);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool UpdateTheLoai(TheLoai theLoai)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"UPDATE TheLoai
                             SET TenLoai = @tenloai WHERE MaLoai = @maloai";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@maloai", theLoai.MaLoai);
                cmd.Parameters.AddWithValue("@tenloai", theLoai.TenLoai);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}