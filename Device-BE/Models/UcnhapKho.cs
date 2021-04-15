using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class UcnhapKho
    {
        public UcnhapKho()
        {
            UcchiTietNhapKho = new HashSet<UcchiTietNhapKho>();
        }

        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string SoHd { get; set; }
        public Guid? IdNguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public Guid? IdTrangThai { get; set; }
        public string GhiChu { get; set; }
        public decimal? TongTien { get; set; }

        public virtual Htuser IdNguoiTaoNavigation { get; set; }
        public virtual CmtuDien IdTrangThaiNavigation { get; set; }
        public virtual ICollection<UcchiTietNhapKho> UcchiTietNhapKho { get; set; }
    }
}
