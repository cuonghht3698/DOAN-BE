using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMTinhThanh
    {
        public System.Guid Id { get; set; }
        [StringLength(100)]
        public string Ten { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> UuTien { get; set; }
        [StringLength(1000)]
        public string MoTa { get; set; }
        public Nullable<System.Guid> IdCapTren { get; set; }
        [ForeignKey("IdLoaiTinhThanh")]
        public CMTuDien CMTuDien { get; set; }
    }
}
