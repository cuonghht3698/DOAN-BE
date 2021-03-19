using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class CartShowPageModel
    {
        public string Id { get; set; }
        public string TinNhan { get; set; }
        public string TongTien { get; set; }
        public string ThoiGianTao { get; set; }
        public string UserId { get; set; }
        public string TenNguoiTao { get; set; }
        public string TrangThai { get; set; }
        public string NhanVienId { get; set; }
        public string TenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public CartDetailModel DmCart { get; set; }

    }
}
