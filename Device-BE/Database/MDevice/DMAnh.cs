using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMAnh
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(250)]
        [Required]
        public string ImageUrl { get; set; }
        public int UuTien { get; set; }
        public bool Active { get; set; }

        [ForeignKey("IdLoaiAnh")]
        public CMTuDien CMTuDien { get; set; }
    }
}
