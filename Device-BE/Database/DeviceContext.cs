using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Device_BE.Models.MDevice;
using Device_BE.Models.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Device_BE.Models
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<CMLoaiTuDien> CMLoaiTuDiens { get; set; }
        public virtual DbSet<CMTuDien> CMTuDiens { get; set; }
        public virtual DbSet<DMAnh> DMAnhs { get; set; }
        public virtual DbSet<DMBaoCao> DMBaoCaos { get; set; }
        public virtual DbSet<DMCart> DMCarts { get; set; }
        public virtual DbSet<DMCartDetail> DMCartDetails { get; set; }
        public virtual DbSet<DMCauHinh> DMCauHinhs { get; set; }
        public virtual DbSet<DMChiNhanh> DMChiNhanhs { get; set; }
        public virtual DbSet<DMKho> DMKhoes { get; set; }
        public virtual DbSet<DMNhaCungCap> DMNhaCungCaps { get; set; }
        public virtual DbSet<DMPhongBan> DMPhongBans { get; set; }
        public virtual DbSet<DMSanPham> DMSanPhams { get; set; }
        public virtual DbSet<DMTinhThanh> DMTinhThanhs { get; set; }
        public virtual DbSet<HSCmt> HSCmts { get; set; }
        public virtual DbSet<HSTinNhan> HSTinNhans { get; set; }
        public virtual DbSet<HSTraLoiCmt> HSTraLoiCmts { get; set; }
        public virtual DbSet<HSTraLoiTinNhan> HSTraLoiTinNhans { get; set; }
        public virtual DbSet<HTMenu> HTMenus { get; set; }
        public virtual DbSet<HTRole> HTRoles { get; set; }
        public virtual DbSet<HTRoleMenu> HTRoleMenus { get; set; }
        public virtual DbSet<HTUser> HTUsers { get; set; }
        public virtual DbSet<HTUserRole> HTUserRoles { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CMLoaiTuDien>().ToTable("CMLoaiTuDien");
            modelBuilder.Entity<CMTuDien>().ToTable("CMTuDien");
            modelBuilder.Entity<DMAnh>().ToTable("DMAnh");
            modelBuilder.Entity<HTUser>().ToTable("HTUser");
            modelBuilder.Entity<DMDiaChi>().ToTable("DMDiaChi");
            modelBuilder.Entity<HTRole>().ToTable("HTRole");
            modelBuilder.Entity<HTMenu>().ToTable("HTMenu");
            modelBuilder.Entity<HTRoleMenu>().ToTable("HTRoleMenu");
            modelBuilder.Entity<HTUserRole>().ToTable("HTUserRole").HasKey(k => new { k.RoleId, k.UserId });
            modelBuilder.Entity<DMTinhThanh>().ToTable("DMTinhThanh");
            modelBuilder.Entity<DMChiNhanh>().ToTable("DMChiNhanh");
            modelBuilder.Entity<DMPhongBan>().ToTable("DMPhongBan");
            modelBuilder.Entity<DMKho>().ToTable("DMKho");
            modelBuilder.Entity<DMNhaCungCap>().ToTable("DMNhaCungCap");
            modelBuilder.Entity<DMSanPham>().ToTable("DMSanPham");
            modelBuilder.Entity<DMCauHinh>().ToTable("DMCauHinh");
            modelBuilder.Entity<DMCart>().ToTable("DMCart");
            modelBuilder.Entity<DMCartDetail>().ToTable("DMCartDetail");
            modelBuilder.Entity<DMBaoCao>().ToTable("DMBaoCao");
            modelBuilder.Entity<HSCmt>().ToTable("HSCmt");
            modelBuilder.Entity<HSTraLoiCmt>().ToTable("HSTraLoiCmt");
            modelBuilder.Entity<HSTinNhan>().ToTable("HSTinNhan");
            modelBuilder.Entity<HSTraLoiTinNhan>().ToTable("HSTraLoiTinNhan");
            modelBuilder.Seed2();
            //modelBuilder.SeedData();
        }





    }
}
