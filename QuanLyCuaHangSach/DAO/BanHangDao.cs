using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class BanHangDao
    {
        string connectionString =
           ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public DataSet GetAllKhachHang()
        {
            DataSet dataset = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM KhachHang", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dataset);
            return dataset;
        }

        public bool CheckMaHD(string mahd)
        {
            string sql = @"SELECT COUNT(*)
        FROM HoaDon
        WHERE MaHD = @mahd";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mahd", mahd);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
                //if (count >= 1) return true;
                //else return false;
            }
        }
        public bool InsertHD(HDon hDon)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO
        HoaDon(MaHD,MaKH,NgayBan)
        VALUES (@mahd,@makh,@ngayban)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@mahd", hDon.MaHD);
                cmd.Parameters.AddWithValue("@makh", hDon.MaKH);
                cmd.Parameters.AddWithValue("@ngayban", hDon.NgayBan);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool InsertCTHD(ChiTietHoaDon chiTietHoaDon)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO
        ChiTietHoaDon(MaHD,MaSach,SoLuong,DonGia,TongTien)
        VALUES (@mahd,@masach,@soluong,@dongia,@dongia*@soluong)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@mahd", chiTietHoaDon.MaHD);
                cmd.Parameters.AddWithValue("@dongia", chiTietHoaDon.DonGia);
                cmd.Parameters.AddWithValue("@soluong", chiTietHoaDon.SoLuong);
                cmd.Parameters.AddWithValue("@masach", chiTietHoaDon.MaSach);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool UpdateSLSach(int soluong,string masach)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"UPDATE Sach
                             SET SoLuong = @soluong
                             WHERE MaSach = @masach";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@masach", masach);
                cmd.Parameters.AddWithValue("@soluong", soluong);
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