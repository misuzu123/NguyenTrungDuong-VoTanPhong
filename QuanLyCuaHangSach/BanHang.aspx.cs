using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCuaHangSach
{
    public partial class BanHang : System.Web.UI.Page
    {

        private HDon LayDuLieuTuForm()
        {
            DateTime dateTime = DateTime.Now;
            string mahd = txtMaHD.Text;
            string makh = DDLKhachHang.SelectedValue;
            string ngayban = dateTime.ToString();
            HDon hDon = new HDon
            {
                MaHD = mahd,
                MaKH = makh,
                NgayBan = ngayban
            };
            return hDon;
        }
        private ChiTietHoaDon LayDuLieuTuForm1()
        {
            string mahd = txtMaHD.Text;
            string masach = txtMaSach.Text;
            int dongia = int.Parse(txtGia.Text);
            int soluong = int.Parse(txtSoLuong.Text);
            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon
            {
                MaHD = mahd,
                SoLuong = soluong,
                DonGia = dongia,
                MaSach = masach
            };
            return chiTietHoaDon;
        }
        private void LayDuLieuVaoGridView()
        {
            SachDAO sachDAO = new SachDAO();
            GridView1.DataSource = sachDAO.GetAllSach();
            GridView1.DataBind();
        }
        private void DoDuLieuLenForm(Sach sach)
        {
            txtMaSach.Text = sach.MaSach;
            txtTenSach.Text = sach.TenSach;
            txtTacGia.Text = sach.TacGia;
            txtGia.Text = sach.DonGia.ToString();
            imgSach.ImageUrl = "~/Images/" + sach.TenFileAnh.ToString();

        }
        public void LoadDropdownlistKhachHang()
        {
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            DDLKhachHang.DataSource = khachHangDAO.GetAllKhachHang();
            DDLKhachHang.DataTextField = "HoTen";
            DDLKhachHang.DataValueField = "MaKH";
            DDLKhachHang.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdownlistKhachHang();
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

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tensach = txtTimSach.Text;
            SachDAO sachDAO = new SachDAO();
            GridView1.DataSource = sachDAO.TimTheoTenSach(tensach);
            GridView1.DataBind();
        }

        protected void btnBan_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị từ giao diện
            int dongia = int.Parse(txtGia.Text);
            int soluongban = int.Parse(txtSoLuong.Text);
            int tongtien = dongia * soluongban;
            int soluongsach = int.Parse(GridView1.SelectedRow.Cells[4].Text);
            string masach = GridView1.SelectedRow.Cells[0].Text;
            int slton = soluongsach - soluongban;
            HDon hDon = LayDuLieuTuForm();
            ChiTietHoaDon chiTietHoaDon = LayDuLieuTuForm1();
            BanHangDao banHangDao = new BanHangDao();
            bool exist = banHangDao.CheckMaHD(hDon.MaHD);
            if (exist != true)
            {
                if (soluongsach >= soluongban)
                {// Thực hiện ghi xuống CSDL
                    bool result = banHangDao.InsertHD(hDon);
                    bool result2 = banHangDao.InsertCTHD(chiTietHoaDon);
                    bool result3 = banHangDao.UpdateSLSach(slton, masach);
                    if (result && result2 && result3)
                    {
                        lblMessage.Text = "Bán thành công! Tống tiền là:" + tongtien;
                        LayDuLieuVaoGridView();
                    }
                    else
                    {
                        lblMessage.Text = "Có lỗi. Vui lòng thử lại sau";
                    }
                }
                else
                {
                    lblMessage.Text = "Không đủ số lượng sách để bán";
                }
            }
            else
            {
                lblMessage.Text = "Mã sách đã tồn tại";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masach = GridView1.SelectedRow.Cells[0].Text;
            SachDAO sachDAO = new SachDAO();
            Sach sach = sachDAO.GetTheLoaiByMaSach(masach);
            if (sach != null)
            {
                // Đổ dữ liệu từ đối tượng Sách vào các trường trên Form
                DoDuLieuLenForm(sach);
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "1";
            txtTimSach.Text = "";
            lblMessage.Text = "";
            txtMaHD.Text = "HD01";
            DDLKhachHang.SelectedValue = default;
            imgSach.ImageUrl = null;
            LayDuLieuVaoGridView();
        }
    }
}