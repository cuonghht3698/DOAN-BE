using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Device_BE.Models.MDevice
{
    public class CMTuDien
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string MaTuDien { get; set; }
        public Guid? LoaiTuDienId { get; set; }

        [StringLength(50)]
        public string TenNgan { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(100)]
        public string GhiChu { get; set; }
        public int UuTien { get; set; }
        public bool Active { get; set; }

        public virtual CMLoaiTuDien LoaiTuDien { get; set; }


    }
}
