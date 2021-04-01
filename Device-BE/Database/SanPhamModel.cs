using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class SanPhamModel
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string TenNgan { get; set; }
        public string MoTa { get; set; }
        public string SeriesNumber { get; set; }
        public string Color { get; set; }
        public decimal? Gia { get; set; }
        public string TrangThai { get; set; }
        public string NhaCungCap { get; set; }
        public string NguoiNhap { get; set; }
        public string Kho { get; set; }
        public string LoaiSp { get; set; }
        public int? KhuyenMai { get; set; }
        public string CauHinh { get; set; }
        public int? Rate { get; internal set; }
        public int? ViewCount { get; internal set; }
        public DateTime? ThoiGianTao { get; internal set; }
        public DateTime? ThoiGianDong { get; internal set; }
        public bool Active { get; set; }
        public string ThongSoKyThuat { get; set; }
    }
}
