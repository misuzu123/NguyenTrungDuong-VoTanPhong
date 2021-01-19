using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class SachDAO
    {
        string connectionString =
           ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public DataTable TimTheoTenSach(string tensach)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM Sach WHERE TenSach LIKE N'%"+tensach+"%'", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public DataSet GetAllTheLoai()
        {
            DataSet dataset = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM TheLoai", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dataset);
            return dataset;
        }
        public DataSet GetAllNXB()
        {
            DataSet dataset = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM NXB", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dataset);
            return dataset;
        }

        public DataTable GetAllSachByMaLoai(string maloai)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM Sach WHERE MaLoai = @maloai";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@maloai", maloai);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
        public int GetSLSach()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Sach", connection);
            connection.Open();
            int count = (int)command.ExecuteScalar();
            return count;
        }
        public bool CheckMaSach(string maSach)
        {
            string sql = @"SELECT COUNT(*)
        FROM Sach
        WHERE MaSach = @masach";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@masach", maSach);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
                //if (count >= 1) return true;
                //else return false;
            }
        }

        public bool Insert(Sach sach)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO
        Sach(MaSach,TenSach,TacGia,DonGia,SoLuong,MoTa,TenFileAnh,MaLoai,MaNXB,NamXB)
        VALUES (@masach,@tensach,@tacgia,@dongia,@soluong,@mota,@tenfileanh,@maloai,@manxb,@namxb)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@masach", sach.MaSach);
                cmd.Parameters.AddWithValue("@tensach", sach.TenSach);
                cmd.Parameters.AddWithValue("@tacgia", sach.TacGia);
                cmd.Parameters.AddWithValue("@dongia", sach.DonGia);
                cmd.Parameters.AddWithValue("@soluong", sach.SoLuong);
                cmd.Parameters.AddWithValue("@mota", sach.MoTa);
                cmd.Parameters.AddWithValue("@tenfileanh", sach.TenFileAnh);
                cmd.Parameters.AddWithValue("@maloai", sach.MaLoai);
                cmd.Parameters.AddWithValue("@manxb", sach.MaNXB);
                cmd.Parameters.AddWithValue("@namxb", sach.NamXB);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public DataTable GetAllSach()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM Sach", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public Sach GetTheLoaiByMaSach(string masach)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Sach WHERE MaSach = @masach";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@masach", masach);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Sach sach = new Sach
                    {
                        // Lấy giá trị theo tên cột trong CSDL,
                        MaSach = (string)reader["MaSach"],
                        TenSach = (string)reader["TenSach"],
                        TacGia = (string)reader["TacGia"],
                        DonGia = (int)reader["Dongia"],
                        SoLuong= (int)reader["SoLuong"],
                        MoTa = (string)reader["MoTa"],
                        TenFileAnh = (string)reader["TenFileAnh"],
                        MaLoai = (string)reader["MaLoai"],
                        MaNXB = (string)reader["MaNXB"],
                        NamXB = (int)reader["NamXB"]
                    };
                    return sach;
                }
            }
            return null;
        }
        public bool DeleteSach(String masach)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"delete from Sach WHERE MaSach=@masach";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@masach", masach);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool UpdateSach(Sach sach)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"UPDATE Sach
                             SET TenSach = @tensach, TacGia = @tacgia, DonGia = @dongia, SoLuong = @soluong, MoTa = @mota, TenFileAnh = @tenfileanh,  Maloai = @maloai, MaNXB = @manxb, NamXB = @namxb
                             WHERE MaSach = @masach";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@masach", sach.MaSach);
                cmd.Parameters.AddWithValue("@tensach", sach.TenSach);
                cmd.Parameters.AddWithValue("@tacgia", sach.TacGia);
                cmd.Parameters.AddWithValue("@dongia", sach.DonGia);
                cmd.Parameters.AddWithValue("@soluong", sach.SoLuong);
                cmd.Parameters.AddWithValue("@mota", sach.MoTa);
                cmd.Parameters.AddWithValue("@tenfileanh", sach.TenFileAnh);
                cmd.Parameters.AddWithValue("@maloai", sach.MaLoai);
                cmd.Parameters.AddWithValue("@manxb", sach.MaNXB);
                cmd.Parameters.AddWithValue("@namxb", sach.NamXB);
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