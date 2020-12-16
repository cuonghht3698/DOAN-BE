using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class HstraLoiTinNhan
    {
        public Guid Id { get; set; }
        public Guid? IdTinNhan { get; set; }
        public string NoiDung { get; set; }
        public bool? Active { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public bool? Watched { get; set; }

        public virtual HstinNhan IdTinNhanNavigation { get; set; }
    }
}
