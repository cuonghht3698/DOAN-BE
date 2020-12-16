using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class Htrole
    {
        public Htrole()
        {
            HtroleMenu = new HashSet<HtroleMenu>();
            HtuserRole = new HashSet<HtuserRole>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<HtroleMenu> HtroleMenu { get; set; }
        public virtual ICollection<HtuserRole> HtuserRole { get; set; }
    }
}
