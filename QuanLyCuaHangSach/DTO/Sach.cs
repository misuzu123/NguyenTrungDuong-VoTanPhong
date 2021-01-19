using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class Sach
    {
        string maSach;
        string tenSach;
        string tacGia;
        int donGia;
        int soLuong;
        string moTa;
        string tenFileAnh;
        string maLoai;
        string maNXB;
        int namXB;
        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string TenFileAnh { get => tenFileAnh; set => tenFileAnh = value; }
        public string MaLoai { get => maLoai; set => maLoai = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public string MaNXB { get => maNXB; set => maNXB = value; }
        public int NamXB { get => namXB; set => namXB = value; }
    }
}