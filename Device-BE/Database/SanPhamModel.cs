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
        public Guid? TrangThaiId { get; set; }
        public Guid? NhaCungCapId { get; set; }
        public Guid? NguoiNhapId { get; set; }
        public Guid? KhoId { get; set; }
        public Guid? LoaiSpid { get; set; }
        public int? KhuyenMai { get; set; }
        public Guid? CauHinhId { get; set; }
        public int? Rate { get; internal set; }
        public int? ViewCount { get; internal set; }
        public DateTime? ThoiGianTao { get; internal set; }
        public DateTime? ThoiGianDong { get; internal set; }
        public string TrangThai { get; internal set; }
        public string NhaCungCap { get; internal set; }
        public bool Active { get; set; }
    }
}
