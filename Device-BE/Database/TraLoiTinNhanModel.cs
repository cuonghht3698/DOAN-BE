using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class TraLoiTinNhanModel
    {
        public Guid? Id { get; set; }
        public Guid? IdTinNhan { get; set; }
        public string NoiDung { get; set; }
        public bool? Active { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public bool? Watched { get; set; }
    }
}
