using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class Hscmt
    {
        public Hscmt()
        {
            HstraLoiCmt = new HashSet<HstraLoiCmt>();
        }

        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? IdSanPham { get; set; }
        public string NoiDung { get; set; }
        public bool? Active { get; set; }
        public DateTime? ThoiGianTao { get; set; }

        public virtual DmsanPham IdSanPhamNavigation { get; set; }
        public virtual Htuser User { get; set; }
        public virtual ICollection<HstraLoiCmt> HstraLoiCmt { get; set; }
    }
}
