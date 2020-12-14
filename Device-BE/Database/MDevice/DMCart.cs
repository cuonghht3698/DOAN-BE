using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMCart
    {
        public System.Guid Id { get; set; }
        [StringLength(1000)]
        public string TinNhan { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public Nullable<System.DateTime> ThoiGianTao { get; set; }
        public Nullable<System.Guid> IdLoaiGD { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<System.Guid> IdTrangThai { get; set; }
        [ForeignKey("IdLoaiGD")]
        public CMTuDien CMTuDien1 { get; set; }
        [ForeignKey("UserId")]
        public HTUser HTUser { get; set; }
        [ForeignKey("IdTrangThai")]
        public CMTuDien CMTuDien2 { get; set; }
    }
}
