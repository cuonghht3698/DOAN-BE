using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class HSTinNhan
    {
        public System.Guid Id { get; set; }
        [ForeignKey("UserId")]
        public HTUser HTUser { get; set; }
        [ForeignKey("IdTrangThai")]
        public CMTuDien CMTuDien { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> ThoiGianTao { get; set; }
    }
}
