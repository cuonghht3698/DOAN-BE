using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models
{
    public class SearchModel
    {
  
        public string sSearch { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public string LoaiSP { get; set; }
        public string HangSX { get; set; }

        public decimal GiaTu { get; set; }
        public decimal GiaDen { get; set; }

        public string Ram { get; set; }
        public string DungLuong { get; set; }

        public Guid? LoaiTuDienId { get; set; }
        public Guid? IdLoaiSanPham { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? TrangThaiId { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public Guid? IdNguoiTao { get; set; }

    }
}
