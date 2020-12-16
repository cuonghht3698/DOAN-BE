using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class DmtinhThanh
    {
        public DmtinhThanh()
        {
            InverseParent = new HashSet<DmtinhThanh>();
        }

        public Guid Id { get; set; }
        public string Ten { get; set; }
        public bool? Active { get; set; }
        public int? UuTien { get; set; }
        public string MoTa { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? IdLoaiTinhThanh { get; set; }

        public virtual CmtuDien IdLoaiTinhThanhNavigation { get; set; }
        public virtual DmtinhThanh Parent { get; set; }
        public virtual ICollection<DmtinhThanh> InverseParent { get; set; }
    }
}
