using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class ColorSanPham
    {
        public Guid Id { get; set; }
        public Guid? OptionSanPhamId { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ChenhGia { get; set; }
        public string Anh { get; set; }
        public string Color { get; set; }

        public virtual OptionSanPham OptionSanPham { get; set; }
    }
}
