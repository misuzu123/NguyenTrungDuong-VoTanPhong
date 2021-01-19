using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyCuaHangSach.DTO
{
    public class NXB
    {
        string maNXB;
        string tenNXB;
        string diaChi;

        public string MaNXB { get => maNXB; set => maNXB = value; }
        public string TenNXB { get => tenNXB; set => tenNXB = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}