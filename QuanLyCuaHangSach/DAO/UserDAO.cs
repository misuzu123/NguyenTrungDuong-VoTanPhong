using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class UserDAO
    {
        string connectionString =
        ConfigurationManager.ConnectionStrings["QLSach"].ConnectionString;
        public bool CheckUserPass(string userName, string passWord)
        {
            string sql = @"SELECT COUNT(*)
        FROM NguoiDung
        WHERE UserName = @username AND Password = @password";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", userName);
                command.Parameters.AddWithValue("@password", passWord);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
                //if (count >= 1) return true;
                //else return false;
            }
        }
    }
}