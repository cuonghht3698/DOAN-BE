using Device_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class ViewSanPhamModel
    {
        public Guid IdSp { get; set; }
        public string Ten { get; set; }
        public string DungLuong { get; set; }
        public string ImageUrl { get; set; }
        public int Rate { get; set; }
        public decimal? Gia { get; set; }

        public int ViewCount { get; set; }

        public string Hang { get; set; }

    }
}
