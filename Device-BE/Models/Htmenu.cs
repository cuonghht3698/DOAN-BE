using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class Htmenu
    {
        public Htmenu()
        {
            HtroleMenu = new HashSet<HtroleMenu>();
        }

        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Ten { get; set; }
        public string Controller { get; set; }
        public string Link { get; set; }
        public string Mota { get; set; }
        public bool? IsParent { get; set; }

        public virtual ICollection<HtroleMenu> HtroleMenu { get; set; }
    }
}
