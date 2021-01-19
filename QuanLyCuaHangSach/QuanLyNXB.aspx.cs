using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCuaHangSach.DAO;
using QuanLyCuaHangSach.DTO;

namespace QuanLyCuaHangSach
{
    public partial class QuanLyNXB : System.Web.UI.Page
    {
        private void LayDuLieuVaoGridView()
        {
            NXBDAO nXBDAO = new NXBDAO();
            GridView1.DataSource = nXBDAO.GetAllNXB();
            GridView1.DataBind();
        }
        private void DoDuLieuLenForm(NXB nxb)
        {
            txtMaNXB.Text = nxb.MaNXB;
            txtTenNXB.Text = nxb.TenNXB;
            txtDiaChi.Text = nxb.DiaChi;
        }
        private NXB LayDuLieuTuForm()
        {
            string manxb = txtMaNXB.Text;
            string tennxb = txtTenNXB.Text;
            string diachi = txtDiaChi.Text;
            NXB nXB = new NXB
            {
                MaNXB = manxb,
                TenNXB = tennxb,
                DiaChi = diachi
            };
            return nXB;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuVaoGridView();
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

        protected void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị từ giao diện
            NXB nXB = LayDuLieuTuForm();
            NXBDAO nXBDAO = new NXBDAO();
            // Kiểm tra username này đã tồn tại trong CSDL chưa
            bool exist = nXBDAO.CheckNXB(nXB.MaNXB);
            if (exist)
            {
                lblMessage.Text = "Tài khoản đã tồn tại";
            }
            else
            {
                // Thực hiện ghi xuống CSDL
                bool result = nXBDAO.Insert(nXB);

                if (result)
                {
                    lblMessage.Text = "Thêm thành công!";
                    LayDuLieuVaoGridView();
                }
                else
                {
                    lblMessage.Text = "Có lỗi. Vui lòng thử lại sau";
                }
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            NXBDAO nXBDAO = new NXBDAO();
            string manxb = txtMaNXB.Text;
            // Kiểm tra username này đã tồn tại trong CSDL chưa
            bool exist = nXBDAO.CheckNXB(manxb);
            if (exist)
            {
                // Thực hiện xóa từ CSDL
                bool result = nXBDAO.DeleteNXB(manxb);
                if (result)
                {
                    lblMessage.Text = "Xóa thể loại thành công!";
                    LayDuLieuVaoGridView();
                }
                else
                {
                    lblMessage.Text = "Có lỗi. Vui lòng thử lại sau";
                }
            }
            else
            {
                lblMessage.Text = "Mã loại không tồn tại";
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            NXB nXB = LayDuLieuTuForm();
            NXBDAO nXBDAO = new NXBDAO();
            bool result = nXBDAO.UpdateNXB(nXB);
            if (result)
            {
                lblMessage.Text = "Cập nhật thành công";
                LayDuLieuVaoGridView();
            }
            else
            {
                lblMessage.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string manxb = GridView1.SelectedRow.Cells[0].Text;
            NXBDAO nXBDAO = new NXBDAO();
            NXB nXB = nXBDAO.GetTheLoaiByMaNXB(manxb);
            if (nXB != null)
            {
                // Đổ dữ liệu từ đối tượng TheLoai vào các trường trên Form
                DoDuLieuLenForm(nXB);
            }
        }
    }
}