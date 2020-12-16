using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class DmchiNhanh
    {
        public DmchiNhanh()
        {
            Dmkho = new HashSet<Dmkho>();
            DmphongBan = new HashSet<DmphongBan>();
        }

        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string Mota { get; set; }
        public string Phone { get; set; }
        public string DiaChi { get; set; }
        public int? UuTien { get; set; }
        public bool? Active { get; set; }
        public DateTime? ThoiGianTao { get; set; }

        public virtual ICollection<Dmkho> Dmkho { get; set; }
        public virtual ICollection<DmphongBan> DmphongBan { get; set; }
    }
}
