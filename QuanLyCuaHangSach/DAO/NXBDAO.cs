using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using QuanLyCuaHangSach.DTO;

namespace QuanLyCuaHangSach.DAO
{
    public class NXBDAO
    {
        string connectionString =
          ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public bool CheckNXB(string manxb)
        {
            string sql = @"SELECT COUNT(*)
        FROM NXB
        WHERE MaNXB = @manxb";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@manxb", manxb);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
                //if (count >= 1) return true;
                //else return false;
            }
        }
        public bool Insert(NXB nXB)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO
        NXB(MaNXB,TenNXB,DiaChi)
        VALUES (@manxb,@tennxb,@diachi)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manxb", nXB.MaNXB);
                cmd.Parameters.AddWithValue("@tennxb", nXB.TenNXB);
                cmd.Parameters.AddWithValue("@diachi", nXB.DiaChi);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public DataTable GetAllNXB()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM NXB", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public NXB GetTheLoaiByMaNXB(string manxb)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM NXB WHERE MaNXB = @manxb";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manxb", manxb);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NXB nXB = new NXB
                    {
                        // Lấy giá trị theo tên cột trong CSDL,
                         MaNXB = (string)reader["MaNXB"],
                        TenNXB = (string)reader["TenNXB"],
                        DiaChi = (string)reader["DiaChi"]
                    };
                    return nXB;
                }
            }
            return null;
        }
        public bool DeleteNXB(String manxb)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"delete from NXB WHERE MaNXB=@manxb";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manxb", manxb);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool UpdateNXB(NXB nXB)
        {
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                string sql = @"UPDATE NXB
                             SET TenNXB = @tennxb, DiaChi = @diachi WHERE MaNXB = @manxb";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manxb",nXB.MaNXB );
                cmd.Parameters.AddWithValue("@tennxb", nXB.TenNXB);
                cmd.Parameters.AddWithValue("@diachi", nXB.DiaChi);
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