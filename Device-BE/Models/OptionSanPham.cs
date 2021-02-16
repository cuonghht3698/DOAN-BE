using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class OptionSanPham
    {
        public OptionSanPham()
        {
            ColorSanPham = new HashSet<ColorSanPham>();
        }

        public Guid Id { get; set; }
        public Guid? SanPhamId { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public int? Rom { get; set; }
        public int? Ram { get; set; }
        public Guid? TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayHoanThanh { get; set; }

        public virtual DmsanPham SanPham { get; set; }
        public virtual ICollection<ColorSanPham> ColorSanPham { get; set; }
    }
}
