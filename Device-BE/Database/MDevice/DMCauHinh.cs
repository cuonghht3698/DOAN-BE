using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMCauHinh
    {
        [Key]
        public System.Guid Id { get; set; }
        [StringLength(250)]
        public string ManHinh { get; set; }
        [StringLength(250)]
        public string CPU { get; set; }
        [StringLength(250)]
        public string PIN { get; set; }
        [StringLength(250)]
        public string RAM { get; set; }
        public Nullable<System.DateTime> NgaySX { get; set; }
        public Nullable<int> ThoiGianBaoHanh { get; set; }
        [StringLength(250)]
        public string DungLuong { get; set; }
        [StringLength(250)]
        public string MoTa { get; set; }
        [ForeignKey("IdLoaiCauHinh")]
        public CMTuDien CMTuDien { get; set; }
    }
}
