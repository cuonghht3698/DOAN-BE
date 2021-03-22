using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.User
{
    public class InfoUserModel
    {
        public Guid Id { get; set; }
        public string HoTen { get; set; }

        public string DiaChi { get; set; }
        public string Sdt { get; set; }

        public string Role { get; set; }
        public Guid RoleId { get; set; }

    }
}
