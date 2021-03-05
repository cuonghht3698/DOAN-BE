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
        public string? Ma { get; set; }
        public Guid? LoaiTuDienId { get; set; }
    }
}
