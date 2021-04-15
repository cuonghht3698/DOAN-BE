using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database.NhapKho
{
    public class UCChiTietNhapKhoModel
    {
        public Guid Id { get; set; }
        public Guid? IdNhapKho { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IdOption { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public decimal? Gia { get; set; }
        public int? SoLuong { get; set; }
    }
}
