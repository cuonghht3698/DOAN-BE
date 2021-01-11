using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class HtroleMenu
    {
        public HtroleMenu()
        {
            InverseParent = new HashSet<HtroleMenu>();
        }

        public Guid Id { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? MenuId { get; set; }
        public int? UuTien { get; set; }
        public string Mota { get; set; }
        public Guid? ParentId { get; set; }

        public virtual Htmenu Menu { get; set; }
        public virtual HtroleMenu Parent { get; set; }
        public virtual Htrole Role { get; set; }
        public virtual ICollection<HtroleMenu> InverseParent { get; set; }
    }
}
