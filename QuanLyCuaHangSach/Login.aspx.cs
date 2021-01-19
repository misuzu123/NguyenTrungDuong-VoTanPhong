using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class Login : System.Web.UI.Page
    {
        private User LayDuLieuTuForm()
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            User user = new User
            {
                UserName = username,
                PassWord = password
            };
            return user;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null || Session["Password"] != null)
            {
                Response.Redirect("DefaultAdmin.aspx");
            }
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị từ giao diện
            User user = LayDuLieuTuForm();
            UserDAO userDAO = new UserDAO();
            // Kiểm tra username và password  trong CSDL
            bool exist = userDAO.CheckUserPass(user.UserName,user.PassWord);
            if (exist)
            {
                Session["UserName"] = txtUserName.Text;
                Session["Password"] = txtPassword.Text;
                Response.Redirect("DefaultAdmin.aspx");
            }
            else
            {
                lblMessage.Text = "Sai tài khoản hoặc mật khẩu! Vui lòng thử lại";
            }    
               
        }
    }
}