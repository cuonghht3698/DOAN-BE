using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class UcchiTietNhapKho
    {
        public Guid Id { get; set; }
        public Guid? IdNhapKho { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IdOption { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public decimal? Gia { get; set; }
        public int? SoLuong { get; set; }

        public virtual UcnhapKho IdNhapKhoNavigation { get; set; }
        public virtual OptionSanPham IdOptionNavigation { get; set; }
        public virtual DmsanPham IdSanPhamNavigation { get; set; }
    }
}
