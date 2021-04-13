using Device_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.DTO
{
    public class SanPhamDTO
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string ManHinh { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public string ImageUrl { get; set; }

        public string MoTa { get; set; }

        public string Cpu { get; set; }
        public string Pin { get; set; }
        public Decimal Gia { get; set; }


    }

    public class UpLoadAnhSP
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }

    }
}
