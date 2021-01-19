using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach
{
    public class ChiTietHoaDon
    {
        string maHD;
        string maSach;
        int soLuong;
        int donGia;
        float tongTien;

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
    }
}