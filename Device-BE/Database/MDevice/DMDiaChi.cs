using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMDiaChi
    {
        public Guid Id { get; set; }
        [ForeignKey("UserId")]
        public HTUser HTUser { get; set; }
        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }
        [Required]
        [StringLength(100)]
        public string Sdt { get; set; }

        public bool Active { get; set; }
        [ForeignKey("IdLoaiDiaChi")]
        public CMTuDien CMTuDien { get; set; }
    }
}
