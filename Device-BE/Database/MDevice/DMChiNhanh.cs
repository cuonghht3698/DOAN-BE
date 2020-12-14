using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMChiNhanh
    {
        [Key]
        public System.Guid Id { get; set; }
        [StringLength(250)]
        public string Ten { get; set; }
        [StringLength(250)]
        public string Mota { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(250)]
        public string DiaChi { get; set; }
        public Nullable<int> UuTien { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> ThoiGianTao { get; set; }
    }
}
