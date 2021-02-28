using Device_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class ViewSanPhamModel
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }

        public List<OptionSanPham> option { get; set; }
    }
}
