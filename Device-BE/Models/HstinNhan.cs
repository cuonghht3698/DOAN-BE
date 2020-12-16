using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class HstinNhan
    {
        public HstinNhan()
        {
            HstraLoiTinNhan = new HashSet<HstraLoiTinNhan>();
        }

        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? IdTrangThai { get; set; }
        public bool? Active { get; set; }
        public DateTime? ThoiGianTao { get; set; }

        public virtual CmtuDien IdTrangThaiNavigation { get; set; }
        public virtual Htuser User { get; set; }
        public virtual ICollection<HstraLoiTinNhan> HstraLoiTinNhan { get; set; }
    }
}
