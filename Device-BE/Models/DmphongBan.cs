using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class DmphongBan
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public Guid? ChiNhanhId { get; set; }
        public Guid? UserId { get; set; }
        public bool? Active { get; set; }

        public virtual DmchiNhanh ChiNhanh { get; set; }
        public virtual Htuser User { get; set; }
    }
}
