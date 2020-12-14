using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class HTMenu
    {
        public Guid Id { get; set; }
        [StringLength(200)]
        public string Icon { get; set; }
        [StringLength(200)]
        public string Ten { get; set; }
        [StringLength(200)]
        public string Controller { get; set; }
        [StringLength(200)]
        public string Link { get; set; }
        [StringLength(500)]
        public string MoTa { get; set; }
        public Guid IdParent { get; set; }
    }
}
