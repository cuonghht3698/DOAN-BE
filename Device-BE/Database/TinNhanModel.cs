using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class TinNhanModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string HoTen { get; set; }

        public string FirstTinNhan { get; set; }
        public DateTime? NgayTao { get; set; }

        public bool? Watch { get; set; }

    }
}
