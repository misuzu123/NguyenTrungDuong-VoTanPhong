using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class ChiTietSach : System.Web.UI.Page
    {

        private void LayDuLieuVaoGridView()
        {
            ChiTietSachDAO chiTietSachDAO = new ChiTietSachDAO();
            GridView1.DataSource = chiTietSachDAO.GetSach(ViewState["MaSachLayDuoc"].ToString());
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("MaSach") != null)
            {
                ViewState["MaSachLayDuoc"] = Request.QueryString.Get("MaSach");
                LayDuLieuVaoGridView();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            
        }
    }
}