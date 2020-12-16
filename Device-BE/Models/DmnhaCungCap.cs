using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class DmnhaCungCap
    {
        public DmnhaCungCap()
        {
            DmsanPham = new HashSet<DmsanPham>();
        }

        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string Mota { get; set; }
        public string Anh { get; set; }
        public bool? Active { get; set; }
        public DateTime? ThoiGianTao { get; set; }

        public virtual ICollection<DmsanPham> DmsanPham { get; set; }
    }
}
