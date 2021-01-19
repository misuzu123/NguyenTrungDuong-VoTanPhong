using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string User = Session["UserName"].ToString();
            //string Pass = Session["Password"].ToString();

            if (Session["UserName"] != null || Session["Password"] != null)
            {
                Response.Write("Chào bạn: " + Session["UserName"].ToString());
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}