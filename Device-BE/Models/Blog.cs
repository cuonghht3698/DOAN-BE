using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class Blog
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public string TieuDeKhongDau { get; set; }
        public string NoiDung { get; set; }
        public string Link { get; set; }
        public bool? Active { get; set; }
        public Guid? IdSanPham { get; set; }
        public DateTime? ThoiGianTao { get; set; }

        public virtual DmsanPham IdSanPhamNavigation { get; set; }
    }
}
