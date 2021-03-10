using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class OptionSanPham
    {
        public OptionSanPham()
        {
            ColorSanPham = new HashSet<ColorSanPham>();
            DmcartDetail = new HashSet<DmcartDetail>();
        }

        public Guid Id { get; set; }
        public Guid? SanPhamId { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public string Rom { get; set; }
        public string Ram { get; set; }
        public Guid? TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayHoanThanh { get; set; }

        public virtual DmsanPham SanPham { get; set; }
        public virtual ICollection<ColorSanPham> ColorSanPham { get; set; }
        public virtual ICollection<DmcartDetail> DmcartDetail { get; set; }
    }
}
