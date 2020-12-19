using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class CmtuDien
    {
        public CmtuDien()
        {
            DmcartLoaiGiaoDich = new HashSet<Dmcart>();
            DmcartTrangThai = new HashSet<Dmcart>();
            DmcauHinh = new HashSet<DmcauHinh>();
            DmsanPhamLoaiSp = new HashSet<DmsanPham>();
            DmsanPhamTrangThai = new HashSet<DmsanPham>();
            DmtinhThanh = new HashSet<DmtinhThanh>();
            HstinNhan = new HashSet<HstinNhan>();
            Htuser = new HashSet<Htuser>();
        }

        public Guid Id { get; set; }
        public string MaTuDien { get; set; }
        public Guid? LoaiTuDienId { get; set; }
        public string TenNgan { get; set; }
        public string Ten { get; set; }
        public string GhiChu { get; set; }
        public int? UuTien { get; set; }
        public bool? Active { get; set; }

        public virtual CmloaiTuDien LoaiTuDien { get; set; }
        public virtual ICollection<Dmcart> DmcartLoaiGiaoDich { get; set; }
        public virtual ICollection<Dmcart> DmcartTrangThai { get; set; }
        public virtual ICollection<DmcauHinh> DmcauHinh { get; set; }
        public virtual ICollection<DmsanPham> DmsanPhamLoaiSp { get; set; }
        public virtual ICollection<DmsanPham> DmsanPhamTrangThai { get; set; }
        public virtual ICollection<DmtinhThanh> DmtinhThanh { get; set; }
        public virtual ICollection<HstinNhan> HstinNhan { get; set; }
        public virtual ICollection<Htuser> Htuser { get; set; }
    }
}
