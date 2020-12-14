using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMKho
    {
        [Key]
        public System.Guid Id { get; set; }
        [StringLength(200)]
        public string Ten { get; set; }
        [ForeignKey("IdChiNhanh")]
        public Nullable<System.Guid> IdChiNhanh { get; set; }
        public Nullable<bool> Active { get; set; }

    }
}
