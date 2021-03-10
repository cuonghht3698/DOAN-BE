using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class DmcartDetail
    {
        public Guid Id { get; set; }
        public Guid? SanPhamId { get; set; }
        public Guid? CartId { get; set; }
        public int? UuTien { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public Guid OptionId { get; set; }
        public string Mau { get; set; }
        public decimal? Gia { get; set; }
        public int? SoLuong { get; set; }

        public virtual Dmcart Cart { get; set; }
        public virtual OptionSanPham Option { get; set; }
        public virtual DmsanPham SanPham { get; set; }
    }
}
