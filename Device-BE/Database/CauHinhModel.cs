﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class CauHinhModel
    {
        public Guid Id { get; set; }
        public string ManHinh { get; set; }
        public string Cpu { get; set; }
        public string Pin { get; set; }
        public string Ram { get; set; }
        public DateTime? Ngaysx { get; set; }
        public int? ThoiGianBaoHanh { get; set; }
        public string Dungluong { get; set; }
        public string Mota { get; set; }
        public Guid? LoaiCauHinhId { get; set; }
        public string Ten { get; set; }
        public string Code { get; set; }
    }
}
