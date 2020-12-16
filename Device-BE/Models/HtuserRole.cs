using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class HtuserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Htrole Role { get; set; }
        public virtual Htuser User { get; set; }
    }
}
