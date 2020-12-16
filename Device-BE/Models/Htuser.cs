using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class Htuser
    {
        public Htuser()
        {
            Dmcart = new HashSet<Dmcart>();
            DmphongBan = new HashSet<DmphongBan>();
            DmsanPham = new HashSet<DmsanPham>();
            Hscmt = new HashSet<Hscmt>();
            HstinNhan = new HashSet<HstinNhan>();
            HtuserRole = new HashSet<HtuserRole>();
        }

        public Guid Id { get; set; }
        public string HoTen { get; set; }
        public string TenKhongDau { get; set; }
        public string DiaChi { get; set; }
        public int? Tuoi { get; set; }
        public string SoDienThoai { get; set; }
        public string GioiThieu { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Active { get; set; }
        public Guid? AnhId { get; set; }
        public Guid? LoaiTaiKhoanId { get; set; }

        public virtual Dmanh Anh { get; set; }
        public virtual CmtuDien LoaiTaiKhoan { get; set; }
        public virtual ICollection<Dmcart> Dmcart { get; set; }
        public virtual ICollection<DmphongBan> DmphongBan { get; set; }
        public virtual ICollection<DmsanPham> DmsanPham { get; set; }
        public virtual ICollection<Hscmt> Hscmt { get; set; }
        public virtual ICollection<HstinNhan> HstinNhan { get; set; }
        public virtual ICollection<HtuserRole> HtuserRole { get; set; }
    }
}
