using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class KhachHang : System.Web.UI.Page
    {
        private void LayDuLieuVaoGridView()
        {
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            GridView1.DataSource = khachHangDAO.GetAllKhachHang();
            GridView1.DataBind();
        }
        private void DoDuLieuLenForm(KH kH)
        {
            txtMaKH.Text = kH.MaKH;
            txtHoTen.Text = kH.HoTen;
            txtDiaChi.Text = kH.DiaChi;
            txtDienThoai.Text = kH.DienThoai;

        }
        private KH LayDuLieuTuForm()
        {
            string makh = txtMaKH.Text;
            string hoten = txtHoTen.Text;
            string diachi= txtDiaChi.Text;
            string dienthoai = txtDienThoai.Text;
            KH kH = new KH
            {
                MaKH = makh,
                HoTen = hoten,
                DiaChi = diachi,
                DienThoai = dienthoai
            };
            return kH;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuVaoGridView();
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string hoten = txtTimKhachHang.Text;
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            GridView1.DataSource = khachHangDAO.TimTheoTenKH(hoten);
            GridView1.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị từ giao diện
            KH kH = LayDuLieuTuForm();
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            // Kiểm tra username này đã tồn tại trong CSDL chưa
            bool exist = khachHangDAO.CheckMaKH(kH.MaKH);
            if (exist)
            {
                lblMessage.Text = "khách hàng đã tồn tại";
            }
            else
            {
                // Thực hiện ghi xuống CSDL
                bool result = khachHangDAO.Insert(kH);

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
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            string makh = txtMaKH.Text;
            // Kiểm tra username này đã tồn tại trong CSDL chưa
            bool exist = khachHangDAO.CheckMaKH(makh);
            if (exist)
            {
                // Thực hiện xóa từ CSDL
                bool result = khachHangDAO.DeleteKhachHang(makh);
                if (result)
                {
                    lblMessage.Text = "Xóa khách hàng thành công!";
                    LayDuLieuVaoGridView();
                }
                else
                {
                    lblMessage.Text = "Có lỗi. Vui lòng thử lại sau";
                }
            }
            else
            {
                lblMessage.Text = "Khách hàng không tồn tại";
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            KH kH = LayDuLieuTuForm();
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            bool result = khachHangDAO.UpdateKhachHang(kH);
            if (result)
            {
                lblMessage.Text = "Cập nhật khách hàng thành công";
                LayDuLieuVaoGridView();
            }
            else
            {
                lblMessage.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtDienThoai.Text = "";
            txtTimKhachHang.Text = "";
            LayDuLieuVaoGridView();
            lblMessage.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makh = GridView1.SelectedRow.Cells[0].Text;
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            KH kH = khachHangDAO.GetTheLoaiByMaKH(makh);
            if (kH != null)
            {
                // Đổ dữ liệu từ đối tượng TheLoai vào các trường trên Form
                DoDuLieuLenForm(kH);
            }
        }
    }
}