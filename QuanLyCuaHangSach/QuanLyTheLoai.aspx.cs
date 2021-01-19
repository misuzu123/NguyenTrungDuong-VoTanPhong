using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class QuanLyTheLoai : System.Web.UI.Page
    {
        private void LayDuLieuVaoGridView()
        {
            TheLoaiDAO theloaiDAO = new TheLoaiDAO();
            GridView1.DataSource = theloaiDAO.GetAllTheLoai();
            GridView1.DataBind();
        }
        private void DoDuLieuLenForm(TheLoai theLoai)
        {
            txtMaLoai.Text = theLoai.MaLoai;
            txtTenLoai.Text = theLoai.TenLoai;
        }
        private TheLoai LayDuLieuTuForm()
        {
            string maloai = txtMaLoai.Text;
            string tenloai = txtTenLoai.Text;
            TheLoai theLoai = new TheLoai
            {
                MaLoai = maloai,
                TenLoai = tenloai
            };
            return theLoai;
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
            TheLoai theLoai = LayDuLieuTuForm();
            TheLoaiDAO theloaiDAO = new TheLoaiDAO();
            // Kiểm tra username này đã tồn tại trong CSDL chưa
            bool exist = theloaiDAO.CheckMaLoai(theLoai.MaLoai);
            if (exist)
            {
                lblMessage.Text = "Tài khoản đã tồn tại";
            }
            else
            {
                // Thực hiện ghi xuống CSDL
                bool result = theloaiDAO.Insert(theLoai);

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
            TheLoaiDAO theloaiDAO = new TheLoaiDAO();
            string maloai = txtMaLoai.Text;
            // Kiểm tra username này đã tồn tại trong CSDL chưa
            bool exist = theloaiDAO.CheckMaLoai(maloai);
            if (exist)
            {
                    // Thực hiện xóa từ CSDL
                    bool result = theloaiDAO.DeleteTheLoai(maloai);
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
            TheLoai theLoai = LayDuLieuTuForm();
            TheLoaiDAO theloaiDAO = new TheLoaiDAO();
            bool result = theloaiDAO.UpdateTheLoai(theLoai);
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
            string maloai = GridView1.SelectedRow.Cells[0].Text;
            TheLoaiDAO theloaiDAO = new TheLoaiDAO();
            TheLoai theLoai = theloaiDAO.GetTheLoaiByMaLoai(maloai);
            if (theLoai != null)
            {
                // Đổ dữ liệu từ đối tượng TheLoai vào các trường trên Form
                DoDuLieuLenForm(theLoai);
            }
        }
    }
}