using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class ChiTietHD : System.Web.UI.Page
    {
        private void LayDuLieuVaoGridView()
        {
            ChiTietHoaDonDAO chiTietHoaDonDAO = new ChiTietHoaDonDAO();
            GridView1.DataSource = chiTietHoaDonDAO.GetCTHD(ViewState["MaHDLayDuoc"].ToString());
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Get("MaHD")!=null)
            {
                ViewState["MaHDLayDuoc"] = Request.QueryString.Get("MaHD");
                LayDuLieuVaoGridView();
            }
            else
            {
                Response.Redirect("HoaDon.aspx");
            }

        }
    }
}