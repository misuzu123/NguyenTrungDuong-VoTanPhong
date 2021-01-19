using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class KhachHangDAO
    {
        string connectionString =
          ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public DataTable TimTheoTenKH(string hoten)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM KhachHang WHERE HoTen LIKE N'%" + hoten + "%'", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }

        public DataTable GetAllKhachHang()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM KhachHang", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public KH GetTheLoaiByMaKH(string makh)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM KhachHang WHERE MaKH = @makh";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@makh", makh);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    KH kH = new KH
                    {
                        // Lấy giá trị theo tên cột trong CSDL,
                        MaKH = (string)reader["MaKH"],
                        HoTen = (string)reader["HoTen"],
                        DiaChi = (string)reader["DiaChi"],
                        DienThoai = (string)reader["DienThoai"]
                    };
                    return kH;
                }
            }
            return null;
        }
        public bool CheckMaKH(string maKH)
        {
            string sql = @"SELECT COUNT(*)
        FROM KhachHang
        WHERE MaKH = @makh";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@makh", maKH);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
                //if (count >= 1) return true;
                //else return false;
            }
        }
        public bool Insert(KH kH)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO
        KhachHang(MaKH,HoTen,DiaChi,DienThoai)
        VALUES (@makh,@hoten,@diachi,@dienthoai)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@makh", kH.MaKH);
                cmd.Parameters.AddWithValue("@hoten", kH.HoTen);
                cmd.Parameters.AddWithValue("@diachi", kH.DiaChi);
                cmd.Parameters.AddWithValue("@dienthoai", kH.DienThoai);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool DeleteKhachHang(String makh)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"delete from KhachHang WHERE MaKH=@makh";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@makh", makh);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool UpdateKhachHang(KH kH)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"UPDATE KhachHang
                             SET HoTen = @hoten, DiaChi = @diachi, DienThoai = @dienthoai
                             WHERE MaKH = @makh";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@makh", kH.MaKH);
                cmd.Parameters.AddWithValue("@hoten", kH.HoTen);
                cmd.Parameters.AddWithValue("@diachi", kH.DiaChi);
                cmd.Parameters.AddWithValue("@dienthoai", kH.DienThoai);
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