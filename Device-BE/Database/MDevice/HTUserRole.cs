using Device_BE.Models.MDevice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class HTUserRole
    {

        public HTUser User { set; get; }
        public Guid UserId { get; set; }
        public HTRole Role { set; get; }
        public Guid RoleId { get; set; }

    }
}
