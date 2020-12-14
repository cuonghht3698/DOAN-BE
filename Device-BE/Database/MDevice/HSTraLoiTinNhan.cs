using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class HSTraLoiTinNhan
    {
        public System.Guid Id { get; set; }
        [ForeignKey("IdTinNhan")]
        public HSTinNhan HSTinNhan { get; set; }
        [StringLength(500)]
        public string NoiDung { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> ThoiGianTao { get; set; }
        public Nullable<bool> Watched { get; set; }

    }
}
