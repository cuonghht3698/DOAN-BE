using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class DmdiaChi
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public bool? Active { get; set; }
        public Guid? LoaiDiaChiId { get; set; }

        public virtual CmtuDien LoaiDiaChi { get; set; }
        public virtual Htuser User { get; set; }
    }
}
