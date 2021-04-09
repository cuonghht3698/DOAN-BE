using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.DTO
{
    public class TonKhoDAO
    {
        public int STT { get; set; }
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public int TonKho { get; set; }
        public string Kho { get; set; }

    }
}
