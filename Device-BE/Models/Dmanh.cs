using System;
using System.Collections.Generic;

namespace Device_BE.Models
{
    public partial class Dmanh
    {
        public Dmanh()
        {
            DmsanPham = new HashSet<DmsanPham>();
            Htuser = new HashSet<Htuser>();
        }

        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string ImageUrl { get; set; }
        public int? UuTien { get; set; }
        public bool? Active { get; set; }
        public Guid? LoaiAnhId { get; set; }

        public virtual CmtuDien LoaiAnh { get; set; }
        public virtual ICollection<DmsanPham> DmsanPham { get; set; }
        public virtual ICollection<Htuser> Htuser { get; set; }
    }
}
