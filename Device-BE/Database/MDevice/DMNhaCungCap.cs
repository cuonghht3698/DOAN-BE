using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMNhaCungCap
    {
        [Key]
        public System.Guid Id { get; set; }
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(100)]
        public string DiaChi { get; set; }
        [StringLength(100)]
        public string Sdt { get; set; }
        [StringLength(20)]
        public string Mota { get; set; }
        [StringLength(1000)]
        public string Anh { get; set; }
        [StringLength(250)]
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> ThoiGianTao { get; set; }

    }
}
