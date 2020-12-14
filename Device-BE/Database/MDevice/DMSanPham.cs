using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMSanPham    {
        public System.Guid Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Ten { get; set; }
        [Required]
        [StringLength(100)]
        public string TenNgan { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public Nullable<System.DateTime> ThoiGianTao { get; set; }
        public Nullable<System.DateTime> ThoiGianDong { get; set; }
        public string SeriesNumber { get; set; }
        public string Color { get; set; }
        public Nullable<int> KhuyenMai { get; set; }
        public Nullable<decimal> Gia { get; set; }
        [ForeignKey("IdCauHinh")]
        public DMCauHinh DMCauHinh { get; set; }

        [ForeignKey("IdTrangThai")]
        public CMTuDien CMTuDien { get; set; }
        [ForeignKey("IdNhaCungCap")]

        public DMNhaCungCap DMNhaCungCap { get; set; }
        [ForeignKey("IdAnh")]

        public DMAnh DMAnh { get; set; }
        [ForeignKey("IdNguoiNhap")]

        public HTUser HTUser { get; set; }
        [ForeignKey("IdKho")]

        public DMKho DMKho { get; set; }
        [ForeignKey("IdLoaiSP")]

        public CMTuDien CMTuDien1 { get; set; }


    
    }
}
