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
        public string? LoaiSP { get; set; }
        public string? HangSX { get; set; }

        public Guid? LoaiTuDienId { get; set; }
        public Guid? IdLoaiSanPham { get; set; }

        public Guid? TrangThaiId { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }

    }
}
