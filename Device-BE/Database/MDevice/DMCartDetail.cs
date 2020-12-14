using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMCartDetail
    {
        [Key]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> IdSanPham { get; set; }
        public Nullable<int> UuTien { get; set; }
        public Nullable<System.DateTime> ThoiGianTao { get; set; }
        [ForeignKey("IdSanPham")]
        public virtual DMSanPham DMSanPham { get; set; }
    }
}
