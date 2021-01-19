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
    public partial class QuanLySach : System.Web.UI.Page
    {
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
            txtSoLuong.Text = sach.SoLuong.ToString();
            txtMoTa.Text = sach.MoTa;
            txtTenFileAnh.Text = sach.TenFileAnh;
            DDLTheLoai.SelectedValue = sach.MaLoai;
            DDLNXB.SelectedValue = sach.MaNXB;
            txtNamXB.Text = sach.NamXB.ToString();
            imgSach.ImageUrl = "~/Images/" + sach.TenFileAnh.ToString();

        }
        private Sach LayDuLieuTuForm()
        {
            string masach = txtMaSach.Text;
            string tensach = txtTenSach.Text;
            string tacgia = txtTacGia.Text;
            int dongia = int.Parse(txtGia.Text);
            int soluong = int.Parse(txtSoLuong.Text);
            string mota = txtMoTa.Text;
            string tenfileanh = txtTenFileAnh.Text;
            string maloai = DDLTheLoai.SelectedValue;
            string manxb = DDLNXB.SelectedValue;
            int namxb= int.Parse(txtNamXB.Text);
            Sach sach = new Sach
            {
                MaSach=masach,
                TenSach=tensach,
                TacGia=tacgia,
                DonGia=dongia,
                SoLuong=soluong,
                MoTa=mota,
                TenFileAnh=tenfileanh,
                MaLoai=maloai,
                MaNXB = manxb,
                NamXB = namxb
            };
            return sach;
        }
        public void LoadDropdownlistTheLoai()
        {
            SachDAO sachDAO = new SachDAO();
            DDLTheLoai.DataSource = sachDAO.GetAllTheLoai();
            DDLTheLoai.DataTextField = "TenLoai";
            DDLTheLoai.DataValueField = "MaLoai";
            DDLTheLoai.DataBind();

        }
        public void LoadDropdownlistNXB()
        {
            SachDAO sachDAO = new SachDAO();
            DDLNXB.DataSource = sachDAO.GetAllNXB();
            DDLNXB.DataTextField = "TenNXB";
            DDLNXB.DataValueField = "MaNXB";
            DDLNXB.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdownlistTheLoai();
                LoadDropdownlistNXB();
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
            Sach sach = LayDuLieuTuForm();
            SachDAO sachDAO = new SachDAO();
            // Kiểm tra username này đã tồn tại trong CSDL chưa
            bool exist = sachDAO.CheckMaSach(sach.MaSach);
            if (exist)
            {
                lblMessage.Text = "Mã sách đã tồn tại";
            }
            else
            {
                // Thực hiện ghi xuống CSDL
                bool result = sachDAO.Insert(sach);

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
            SachDAO sachDAO = new SachDAO();
            string masach = txtMaSach.Text;
            // Kiểm tra username này đã tồn tại trong CSDL chưa
            bool exist = sachDAO.CheckMaSach(masach);
            if (exist)
            {
                // Thực hiện xóa từ CSDL
                bool result = sachDAO.DeleteSach(masach);
                if (result)
                {
                    lblMessage.Text = "Xóa sách thành công!";
                    LayDuLieuVaoGridView();
                }
                else
                {
                    lblMessage.Text = "Có lỗi. Vui lòng thử lại sau";
                }
            }
            else
            {
                lblMessage.Text = "Sách không tồn tại";
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            Sach sach = LayDuLieuTuForm();
            SachDAO sachDAO = new SachDAO();
            bool result = sachDAO.UpdateSach(sach);
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

        protected void btnUploadAnh_Click(object sender, EventArgs e)
        {
            string TenFileAnhLayDuoc;
            //Tách lấy tên tập tin
            TenFileAnhLayDuoc = FileUpload1.FileName;
            //Thực hiện chép file ảnh lấy được lên thư mục Images nằm trong ứng dụng Website
            FileUpload1.SaveAs(MapPath("~/Images/" + TenFileAnhLayDuoc));

            //Đưa tên ảnh lấy được ra điều khiển Image để hiển thị ảnh
            imgSach.ImageUrl = "~/Images/" + TenFileAnhLayDuoc;

            //Đưa tên ảnh lấy được vào hộp văn bản txtTenFileAnh để hiển thị tên file ảnh lấy được vào hộp văn bản này
            txtTenFileAnh.Text = TenFileAnhLayDuoc;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masach = GridView1.SelectedRow.Cells[0].Text;
            SachDAO sachDAO = new SachDAO();
            Sach sach = sachDAO.GetTheLoaiByMaSach(masach);
            if (sach != null)
            {
                // Đổ dữ liệu từ đối tượng TheLoai vào các trường trên Form
                DoDuLieuLenForm(sach);
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "Sach01";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "";
            txtMoTa.Text = "";
            txtTenFileAnh.Text = "";
            txtTimSach.Text = "";
            DDLTheLoai.SelectedValue = default;
            LayDuLieuVaoGridView();
            lblMessage.Text = "";
            imgSach.ImageUrl = null;
        }

        protected void DDLTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maloai= DDLTheLoai.SelectedValue;
            SachDAO sachDAO = new SachDAO();
            GridView1.DataSource = sachDAO.GetAllSachByMaLoai(maloai);
            GridView1.DataBind();
        }

        protected void btnTimSach_Click(object sender, EventArgs e)
        {
            string tensach = txtTimSach.Text;
            SachDAO sachDAO = new SachDAO();
            GridView1.DataSource = sachDAO.TimTheoTenSach(tensach);
            GridView1.DataBind();
        }
    }
}