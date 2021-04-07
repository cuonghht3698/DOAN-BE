using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.DTO
{
    public class Option
    {
        [Key]
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public Guid SoLuong { get; set; }

    }
}
