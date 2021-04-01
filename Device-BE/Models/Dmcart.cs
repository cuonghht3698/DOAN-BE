using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class Dmcart
    {
        public Dmcart()
        {
            DmcartDetail = new HashSet<DmcartDetail>();
        }

        public Guid Id { get; set; }
        public string TinNhan { get; set; }
        public decimal? TongTien { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public Guid? LoaiGiaoDichId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TrangThaiId { get; set; }
        public Guid? NhanVienId { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }

        public virtual CmtuDien LoaiGiaoDich { get; set; }
        public virtual Htuser NhanVien { get; set; }
        public virtual CmtuDien TrangThai { get; set; }
        public virtual Htuser User { get; set; }
        public virtual ICollection<DmcartDetail> DmcartDetail { get; set; }
    }
}
