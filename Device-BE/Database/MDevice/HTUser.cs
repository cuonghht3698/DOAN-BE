using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class HTUser
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string HoTen { get; set; }
        [StringLength(100)]
        public string TenKhongDau { get; set; }
        [StringLength(100)]
        public string DiaChi { get; set; }
        public Nullable<int> Tuoi { get; set; }
        [StringLength(22)]
        public string Sdt { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }

        public string GioiThieu { get; set; }

        [StringLength(220)]
        public Nullable<Guid> AnhId { get; set; }

        public virtual DMAnh Anh { get; set; }

    }
}
