using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.DTO
{
    public class CartModel
    {
        public Guid Id { get; set; }
        public string TinNhan { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public string LoaiGiaoDich { get; set; }
        public Guid UserId { get; set; }
        public string TrangThai { get; set; }
        public string MaTrangThai { get; set; }

        public Guid? NhanVienId { get; set; }
        public string DiaChi { get; set; }
        public decimal TongTien { get; set; }
        public string Sdt { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
    }
    public class GiaoHangModel
    {
        public Guid Id { get; set; }
        public Guid? NhanVienId { get; set; }
    }
}
