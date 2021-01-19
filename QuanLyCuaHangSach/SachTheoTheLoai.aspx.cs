using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class SachTheoTheLoai : System.Web.UI.Page
    {
        private void LayDuLieuVaoDataList()
        {
            SachTheoTheLoaiDAO sachTheoTheLoaiDAO = new SachTheoTheLoaiDAO();
            DataList1.DataSource = sachTheoTheLoaiDAO.GetAllSachByMaLoai(ViewState["MaLoaiLayDuoc"].ToString());
            DataList1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["MaLoaiLayDuoc"] = Request.QueryString.Get("MaLoai");
            LayDuLieuVaoDataList();
            DemSoLuongSachTheoTheLoai();
        }

        public void DemSoLuongSachTheoTheLoai()
        {
            SachTheoTheLoaiDAO sachTheoTheLoaiDAO = new SachTheoTheLoaiDAO();
            int SL = sachTheoTheLoaiDAO.GetSoLuongSachTheoMaLoai(ViewState["MaLoaiLayDuoc"].ToString());
            lblTongSoSach.Text = "Tìm được [" + SL.ToString() + "] sách";
        }
    }
}