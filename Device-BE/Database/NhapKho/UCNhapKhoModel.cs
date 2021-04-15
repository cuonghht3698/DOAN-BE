using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database.NhapKho
{
    public class UCNhapKhoModel
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string SoHd { get; set; }
        public Guid? IdNguoiTao { get; set; }
        public string NguoiTao { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public decimal? TongTien { get; set; }
        public IEnumerable<UCChiTietNhapKhoModel> DSChitiet { get; set; }
    }
}
