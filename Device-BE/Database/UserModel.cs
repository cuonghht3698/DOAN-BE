
using Device_BE.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models
{
    public class UserModel: BaseModel
    {
        public string HoTen { get; set; }
        public string TenKhongDau { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string GioiThieu { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }

    }

    public class MyProfileModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string TenKhongDau { get; set; }

        public DateTime NgaySinh { get; set; }

        public string GioiThieu { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }

    }


}
