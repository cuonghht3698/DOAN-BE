using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class CmloaiTuDien
    {
        public CmloaiTuDien()
        {
            CmtuDien = new HashSet<CmtuDien>();
        }

        public Guid Id { get; set; }
        public string MaLoai { get; set; }
        public string Ten { get; set; }

        public virtual ICollection<CmtuDien> CmtuDien { get; set; }
    }
}
