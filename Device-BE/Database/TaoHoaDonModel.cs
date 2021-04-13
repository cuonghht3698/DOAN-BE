using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class TaoHoaDonModel
    {
        public Guid NhanVienId { get; set; }
        public string DiaChi { get; set; }
        public decimal TongTien { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public List<OptionModel> DSSanPham { get; set; }

    }
    public class OptionModel
    {
     
        public decimal Gia { get; set; }
        public string TenSanPham { get; set; }
        public Guid OptionId { get; set; }
        public Guid SanPhamId { get; set; }
        public decimal SoLuong { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }


    }

}
