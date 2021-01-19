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
    public partial class UCC_TheLoaiSach : System.Web.UI.UserControl
    {
        private void LayDuLieuVaoGridView()
        {
            UCC_TheLoaiSachDAO uCC_TheLoaiSachDAO = new UCC_TheLoaiSachDAO();
            GridView1.DataSource = uCC_TheLoaiSachDAO.GetAllTheLoai();
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuVaoGridView();
            }
        }
    }      
}