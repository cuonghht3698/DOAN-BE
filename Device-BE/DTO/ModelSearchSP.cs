using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.DTO
{
    public class ModelSearchSP
    {
        public string sSearch { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public bool OrderByAsc { get; set; }

    }
}
