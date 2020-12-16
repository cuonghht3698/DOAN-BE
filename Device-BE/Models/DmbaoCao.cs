using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class DmbaoCao
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string Ten { get; set; }
        public string ThuTuc { get; set; }
        public bool? Active { get; set; }
    }
}
