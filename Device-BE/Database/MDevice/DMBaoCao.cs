using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class DMBaoCao
    {
        [Key]
        public System.Guid Id { get; set; }
        [StringLength(100)]
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(200)]
        public string ThuTuc { get; set; }
        public bool Active { get; set; }
    }
}
