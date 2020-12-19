using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class Dmanh
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string ImageUrl { get; set; }
        public int? UuTien { get; set; }
        public bool? Active { get; set; }
        public Guid? AnhId { get; set; }
    }
}
