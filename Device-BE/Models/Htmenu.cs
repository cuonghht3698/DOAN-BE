using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class Htmenu
    {
        public Htmenu()
        {
            HtroleMenu = new HashSet<HtroleMenu>();
            InverseParent = new HashSet<Htmenu>();
        }

        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Ten { get; set; }
        public string Controller { get; set; }
        public string Link { get; set; }
        public string Mota { get; set; }
        public Guid? ParentId { get; set; }

        public virtual Htmenu Parent { get; set; }
        public virtual ICollection<HtroleMenu> HtroleMenu { get; set; }
        public virtual ICollection<Htmenu> InverseParent { get; set; }
    }
}
