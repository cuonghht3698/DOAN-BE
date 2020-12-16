using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class HstraLoiCmt
    {
        public Guid Id { get; set; }
        public Guid? IdCmt { get; set; }
        public string NoiDung { get; set; }
        public bool? Active { get; set; }
        public DateTime? ThoiGianTao { get; set; }

        public virtual Hscmt IdCmtNavigation { get; set; }
    }
}
