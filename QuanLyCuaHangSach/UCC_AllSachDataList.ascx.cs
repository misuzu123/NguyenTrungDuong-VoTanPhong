using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class UCC_AllSachDataList : System.Web.UI.UserControl
    {
        private void LayDuLieuVaoDataList()
        {
            UCC_AllSachDataListDAO uCC_AllSachDataListDAO = new UCC_AllSachDataListDAO();
            DataList1.DataSource = uCC_AllSachDataListDAO.GetAllSach();
            DataList1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuVaoDataList();
            }
        }
    }
}