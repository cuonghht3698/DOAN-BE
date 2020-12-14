using Device_BE.Models.MDevice;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Device_BE.Models.Seed
{
    public static class SeedUser
    {
        public static void Seed2(this ModelBuilder modelBuilder)
        {
            //seed custom admin role
            modelBuilder.Entity<HTRole>().HasData(new HTRole
            {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d8223497a3"),
                Ten = "Giám Đốc",
                Code = "giamdoc",
                MoTa = "GIAMDOC"
            }, new HTRole {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d5423497a3"),
                Ten = "admin",
                Code = "admin",
                MoTa = "ADMIN"
            }, new HTRole
            {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d8123497a3"),
                Ten = "Nhân viên",
                Code = "nhanvien",
                MoTa = "ADMIN"
            }, new HTRole
            {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d8223497a8"),
                Ten = "Khách hàng",
                Code = "khachhang",
                MoTa = "Khách hàng"
            });
            //seed admins
            modelBuilder.Entity<HTUser>().HasData(new HTUser
            {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                Username = "admin",
                PasswordHash = "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918",
                Email = "cuong@gmail.com",
                HoTen = "ad CườngNB",
                CreateDate = DateTime.Now,
                Active = true,
                DiaChi = "Hà Nội",
                AnhId = null,
                Sdt = null,
                GioiThieu = "Hello world Im Iron Man",
                TenKhongDau = "nbc",
                Tuoi = 22
            }, new HTUser
            {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"),
                Username = "cuong",
                PasswordHash = "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918",
                Email = "cuong@gmail.com",
                HoTen = "KH",
                CreateDate = DateTime.Now,
                Active = true,
                DiaChi = "Hà Nội",
                AnhId = null,
                Sdt = null,
                GioiThieu = "Xin chào hihi",
                TenKhongDau = "nbc",
                Tuoi = 22
            });
            //seed admin into role
            modelBuilder.Entity<HTUserRole>().HasData(new HTUserRole
            {
                RoleId = new Guid("9b76ed13-ce77-4d41-0908-08d5423497a3"),
                UserId = new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3")
            }, new HTUserRole
            {
                RoleId = new Guid("9b76ed13-ce77-4d41-0908-08d8223497a8"),
                UserId = new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2")
            }); ;
        }
    }
}
