using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCuaHangSach.DAO;

namespace QuanLyCuaHangSach
{
    public partial class DSKhachHang : System.Web.UI.Page
    {
        private void LayDuLieuVaoDataList()
        {
            DSKhachHangDAO dSKhachHangDAO = new DSKhachHangDAO();
            DataList1.DataSource = dSKhachHangDAO.GetAllKhachHang();
            DataList1.DataBind();
        }
        private void LayDuLieuVaoDataList2()
        {
            DSKhachHangDAO dSKhachHangDAO = new DSKhachHangDAO();
            DataList1.DataSource = dSKhachHangDAO.GetKhachHang(ViewState["MaKHLayDuoc"].ToString());
            DataList1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if(Request.QueryString.Get("MaKH")!=null)
                {
                    ViewState["MaKHLayDuoc"] = Request.QueryString.Get("MaKH");
                    LayDuLieuVaoDataList2();
                }else
                {
                    LayDuLieuVaoDataList();
                }                          
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