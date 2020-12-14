//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Device_BE.Models.MDevice;
//using Microsoft.EntityFrameworkCore;

//namespace Device_BE.Models.Seed
//{
//    public static class SeedDemo
//    {
//        public static void SeedData(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<CoSo>().HasData(
//                new CoSo
//                {
//                    Id = 1,
//                    Ten = "Cơ Sở KDT Trần Phú",
//                    DiaChi = "V6A09, Phố Victoria, KĐT Văn Phú, Hà Đông, TP. Hà Nội"
//                });
//            modelBuilder.Entity<Kho>().HasData(
//                new Kho
//                {
//                    Id = 2,
//                    Ten = "Kho Trần Phú",
//                    CoSoId = 1,
//                    GhiChu = "Chưa có ghi chú",
//                    TrangThai = true
//                }, new Kho
//                {
//                    Id = 1,
//                    Ten = "Tổng",
//                    CoSoId = 1,
//                    GhiChu = "Chưa có ghi chú",
//                    TrangThai = true
//                });

//            modelBuilder.Entity<PhongBan>().HasData(
//                new Kho
//                {

//                    Id = 1,
//                    Ten = "Phong Triển Khai",
//                    CoSoId = 1,
//                    GhiChu = "Triển khai",
//                    TrangThai = true
//                });

//            modelBuilder.Entity<NhaCungCap>().HasData(new NhaCungCap
//            {
//                Id = 1,
//                Ten = "SumSung",
//                DiaChi = "Hà Nội",
//                TinhTrang = true,
//                MoTa = "Màn Hình Máy tính,Điện Thoại,..."
//            }, new NhaCungCap
//            {
//                Id = 2,
//                Ten = "LG",
//                DiaChi = "Hà Nội",
//                TinhTrang = true,
//                MoTa = "Màn Hình Máy tính,Điện Thoại,..."

//            }, new NhaCungCap
//            {
//                Id = 3,
//                Ten = "Meetion",
//                DiaChi = "Hà Nội",
//                TinhTrang = true,
//                MoTa = "Chuột bàn phím"
//            });
//            modelBuilder.Entity<DanhMucThietBi>().HasData(
//                new DanhMucThietBi
//                {
//                    Id = 1,
//                    Ten = "Điện tử",
//                    MoTa = "Máy vi tính,TV,Điều hòa..",
//                    TinhTrang = true
//                }, new DanhMucThietBi
//                {
//                    Id = 2,
//                    Ten = "Nội thất",
//                    MoTa = "Bàn ghế,.. ",
//                    TinhTrang = true
//                }, new DanhMucThietBi
//                {
//                    Id = 3,
//                    Ten = "Khác",
//                    MoTa = "vv.v..vv",
//                    TinhTrang = true
//                });
//        }
//    }
//}
