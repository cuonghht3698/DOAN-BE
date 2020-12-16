using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class HtroleMenu
    {
        public Guid Id { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? MenuId { get; set; }
        public int? UuTien { get; set; }
        public string Mota { get; set; }

        public virtual Htmenu Menu { get; set; }
        public virtual Htrole Role { get; set; }
    }
}
