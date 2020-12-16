using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class DmsanPham
    {
        public DmsanPham()
        {
            DmcartDetail = new HashSet<DmcartDetail>();
            Hscmt = new HashSet<Hscmt>();
        }

        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string TenNgan { get; set; }
        public string MoTa { get; set; }
        public int? Rate { get; set; }
        public int? ViewCount { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public DateTime? ThoiGianDong { get; set; }
        public string SeriesNumber { get; set; }
        public string Color { get; set; }
        public decimal? Gia { get; set; }
        public Guid? TrangThaiId { get; set; }
        public Guid? NhaCungCapId { get; set; }
        public Guid? AnhId { get; set; }
        public Guid? NguoiNhapId { get; set; }
        public Guid? KhoId { get; set; }
        public Guid? LoaiSpid { get; set; }
        public int? KhuyenMai { get; set; }
        public Guid? CauHinhId { get; set; }

        public virtual Dmanh Anh { get; set; }
        public virtual DmcauHinh CauHinh { get; set; }
        public virtual Dmkho Kho { get; set; }
        public virtual CmtuDien LoaiSp { get; set; }
        public virtual Htuser NguoiNhap { get; set; }
        public virtual DmnhaCungCap NhaCungCap { get; set; }
        public virtual CmtuDien TrangThai { get; set; }
        public virtual ICollection<DmcartDetail> DmcartDetail { get; set; }
        public virtual ICollection<Hscmt> Hscmt { get; set; }
    }
}
