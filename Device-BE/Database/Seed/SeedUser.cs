
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
            modelBuilder.Entity<Htrole>().HasData(new Htrole
            {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d8223497a3"),
                Ten = "Giám Đốc",
                Code = "giamdoc",
                MoTa = "GIAMDOC"
            }, new Htrole {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d5423497a3"),
                Ten = "admin",
                Code = "admin",
                MoTa = "ADMIN"
            }, new Htrole
            {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d8123497a3"),
                Ten = "Nhân viên",
                Code = "nhanvien",
                MoTa = "nhanvien"
            }, new Htrole
            {
                Id = new Guid("9b76ed13-ce77-4d41-0908-08d8223497a8"),
                Ten = "Khách hàng",
                Code = "khachhang",
                MoTa = "Khách hàng"
            });
            //seed admins
            modelBuilder.Entity<Htuser>().HasData(new Htuser
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
                SoDienThoai = null,
                //GioiThieu = "Hello world Im Iron Man",
                TenKhongDau = "nbc",
                NgaySinh = new DateTime()
            }, new Htuser
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
                SoDienThoai = null,
                GioiThieu = "Xin chào hihi",
                TenKhongDau = "nbc",
                NgaySinh = new DateTime()
            });
            //seed admin into role
            modelBuilder.Entity<HtuserRole>().HasData(new HtuserRole
            {
                RoleId = new Guid("9b76ed13-ce77-4d41-0908-08d5423497a3"),
                UserId = new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3")
            }, new HtuserRole
            {
                RoleId = new Guid("9b76ed13-ce77-4d41-0908-08d8223497a8"),
                UserId = new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2")
            }); ;
        }
    }
}
