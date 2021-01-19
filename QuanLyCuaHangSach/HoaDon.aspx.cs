using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class HD : System.Web.UI.Page
    {
        private void LayDuLieuVaoDataList()
        {
            HoaDonDAO hoaDonDAO = new HoaDonDAO();
            DataList1.DataSource = hoaDonDAO.GetAllHoaDon();
            DataList1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuVaoDataList();
            }
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