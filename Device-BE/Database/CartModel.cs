using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class CartModel
    {
        public Guid Id { get; set; }
        public string TinNhan { get; set; }
        public decimal? TongTien { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TrangThaiId { get; set; }
        public Guid? NhanVienId { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }


    }
}
