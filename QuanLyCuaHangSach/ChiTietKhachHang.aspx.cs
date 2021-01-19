using QuanLyCuaHangSach.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class ChiTietKhachHang : System.Web.UI.Page
    {
        private void LayDuLieuVaoGridView()
        {
            ChiTietKhachHangDAO chiTietKhachHangDAO = new ChiTietKhachHangDAO();
            GridView2.DataSource = chiTietKhachHangDAO.GetHDKH(ViewState["MaKHLayDuoc"].ToString());
            GridView2.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString.Get("MaKH") != null)
            {
                ViewState["MaKHLayDuoc"] = Request.QueryString.Get("MaKH");
                LayDuLieuVaoGridView();
                if(GridView2.Rows.Count != 0)
                {
                    tongtiendamuasach();
                }
                else
                {
                    lblTongSoTien.Text = "Khách hàng chưa mua sách!";
                }
            }
            else
            {
                Response.Redirect("DSKhachHang.aspx");
            }

        }
        public void tongtiendamuasach()
        {
            ChiTietKhachHangDAO chiTietKhachHangDAO = new ChiTietKhachHangDAO();
            int sum = chiTietKhachHangDAO.GetTongTienKH(ViewState["MaKHLayDuoc"].ToString());
            lblTongSoTien.Text = "Tổng số tiền khách hàng đã mua sách là: " + sum.ToString() + " đồng";             
        }
    }
}