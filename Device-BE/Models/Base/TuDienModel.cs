using Device_BE.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models
{
    public class TuDienModel:BaseModel
    {
        public string MaTuDien { get; set; }
        public string LoaiTuDien { get; set; }
        public string TenNgan { get; set; }
        public string Ten { get; set; }
        public string GhiChu { get; set; }
        public int UuTien { get; set; }
        public bool Active { get; set; }
        public Guid LoaiTuDienId { get; set; }

    }
}
