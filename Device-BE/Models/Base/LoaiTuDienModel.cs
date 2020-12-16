using Device_BE.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models
{
    public class LoaiTuDienModel : BaseModel
    {
        public string MaLoai { get; set; }
        public string Ten { get; set; }

    }
}
