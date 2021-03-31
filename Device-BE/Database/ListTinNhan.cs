using Device_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class ListTinNhan
    {
        public Guid IdTinNhan { get; set; }

        public IEnumerable<TraLoiTinNhanModel> DSTinNhan { get; set; }
        public int Count { get; set; }
    }
}
