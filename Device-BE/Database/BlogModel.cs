using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class BlogModel
    {
        public Guid? Id { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string Link { get; set; }
        public bool? Active { get; set; }
        public Guid? IdSanPham { get; set; }
        public DateTime? ThoiGianTao { get; set; }
    }
}
