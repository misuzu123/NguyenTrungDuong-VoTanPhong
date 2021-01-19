using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DemSoLuongSach();
            if (Session["UserName"] != null || Session["Password"] != null)
            {
                Session.Clear();
            }
        }
        public void DemSoLuongSach()
        {
            SachDAO sachDAO = new SachDAO();
            int SL = sachDAO.GetSLSach();
            lblTongSoSach.Text = "Có [" + SL.ToString() + "] sách";
        }
    }
}