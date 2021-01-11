using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Device_BE.Models
{
    public partial class QLPhoneContext : DbContext
    {
        public QLPhoneContext()
        {
        }

        public QLPhoneContext(DbContextOptions<QLPhoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CmloaiTuDien> CmloaiTuDien { get; set; }
        public virtual DbSet<CmtuDien> CmtuDien { get; set; }
        public virtual DbSet<Dmanh> Dmanh { get; set; }
        public virtual DbSet<DmbaoCao> DmbaoCao { get; set; }
        public virtual DbSet<Dmcart> Dmcart { get; set; }
        public virtual DbSet<DmcartDetail> DmcartDetail { get; set; }
        public virtual DbSet<DmcauHinh> DmcauHinh { get; set; }
        public virtual DbSet<DmchiNhanh> DmchiNhanh { get; set; }
        public virtual DbSet<DmdiaChi> DmdiaChi { get; set; }
        public virtual DbSet<Dmkho> Dmkho { get; set; }
        public virtual DbSet<DmnhaCungCap> DmnhaCungCap { get; set; }
        public virtual DbSet<DmphongBan> DmphongBan { get; set; }
        public virtual DbSet<DmsanPham> DmsanPham { get; set; }
        public virtual DbSet<DmtinhThanh> DmtinhThanh { get; set; }
        public virtual DbSet<Hscmt> Hscmt { get; set; }
        public virtual DbSet<HstinNhan> HstinNhan { get; set; }
        public virtual DbSet<HstraLoiCmt> HstraLoiCmt { get; set; }
        public virtual DbSet<HstraLoiTinNhan> HstraLoiTinNhan { get; set; }
        public virtual DbSet<Htmenu> Htmenu { get; set; }
        public virtual DbSet<Htrole> Htrole { get; set; }
        public virtual DbSet<HtroleMenu> HtroleMenu { get; set; }
        public virtual DbSet<Htuser> Htuser { get; set; }
        public virtual DbSet<HtuserRole> HtuserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-BJJNCTC;Database=QLPhone;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmloaiTuDien>(entity =>
            {
                entity.ToTable("CMLoaiTuDien");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaLoai).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<CmtuDien>(entity =>
            {
                entity.ToTable("CMTuDien");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GhiChu).HasMaxLength(200);

                entity.Property(e => e.MaTuDien).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.TenNgan).HasMaxLength(50);

                entity.HasOne(d => d.LoaiTuDien)
                    .WithMany(p => p.CmtuDien)
                    .HasForeignKey(d => d.LoaiTuDienId)
                    .HasConstraintName("FK_CMTuDien_LoaiTuDienId");
            });

            modelBuilder.Entity<Dmanh>(entity =>
            {
                entity.ToTable("DMAnh");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.Ten).HasMaxLength(200);
            });

            modelBuilder.Entity<DmbaoCao>(entity =>
            {
                entity.ToTable("DMBaoCao");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NoiDung).IsRequired();

                entity.Property(e => e.Ten)
                    .HasColumnName("TEN")
                    .HasMaxLength(200);

                entity.Property(e => e.ThuTuc).HasMaxLength(200);

                entity.Property(e => e.TieuDe).HasMaxLength(200);
            });

            modelBuilder.Entity<Dmcart>(entity =>
            {
                entity.ToTable("DMCart");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Thoigiantao)
                    .HasColumnName("THOIGIANTAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.TinNhan).HasMaxLength(50);

                entity.Property(e => e.Tongtien)
                    .HasColumnName("TONGTIEN")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.LoaiGiaoDich)
                    .WithMany(p => p.DmcartLoaiGiaoDich)
                    .HasForeignKey(d => d.LoaiGiaoDichId)
                    .HasConstraintName("FK_DMCart_IdLoaiGD");

                entity.HasOne(d => d.TrangThai)
                    .WithMany(p => p.DmcartTrangThai)
                    .HasForeignKey(d => d.TrangThaiId)
                    .HasConstraintName("FK_DMCart_IdTrangThai");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dmcart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DMCart_UserId");
            });

            modelBuilder.Entity<DmcartDetail>(entity =>
            {
                entity.ToTable("DMCartDetail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.DmcartDetail)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_DMCartDetail_CartId");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.DmcartDetail)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("FK_DMCartDetail_IdSanPham");
            });

            modelBuilder.Entity<DmcauHinh>(entity =>
            {
                entity.ToTable("DMCauHinh");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cpu)
                    .HasColumnName("CPU")
                    .HasMaxLength(50);

                entity.Property(e => e.Dungluong)
                    .HasColumnName("DUNGLUONG")
                    .HasMaxLength(50);

                entity.Property(e => e.ManHinh).HasMaxLength(50);

                entity.Property(e => e.Mota)
                    .IsRequired()
                    .HasColumnName("MOTA");

                entity.Property(e => e.Ngaysx)
                    .HasColumnName("NGAYSX")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(50);

                entity.Property(e => e.Ram)
                    .HasColumnName("RAM")
                    .HasMaxLength(50);

                entity.HasOne(d => d.LoaiCauHinh)
                    .WithMany(p => p.DmcauHinh)
                    .HasForeignKey(d => d.LoaiCauHinhId)
                    .HasConstraintName("FK_DMCauHinh_TuDienId");
            });

            modelBuilder.Entity<DmchiNhanh>(entity =>
            {
                entity.ToTable("DMChiNhanh");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Mota).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");
            });

            modelBuilder.Entity<DmdiaChi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DMDiaChi");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Sdt).HasMaxLength(50);

                entity.HasOne(d => d.LoaiDiaChi)
                    .WithMany()
                    .HasForeignKey(d => d.LoaiDiaChiId)
                    .HasConstraintName("FK_DMDiaChi_LoaiDiaChiId");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DMDiaChi_UserId");
            });

            modelBuilder.Entity<Dmkho>(entity =>
            {
                entity.ToTable("DMKho");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.ChiNhanh)
                    .WithMany(p => p.Dmkho)
                    .HasForeignKey(d => d.ChiNhanhId)
                    .HasConstraintName("FK_DMKho_ChiNhanhId");
            });

            modelBuilder.Entity<DmnhaCungCap>(entity =>
            {
                entity.ToTable("DMNhaCungCap");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Mota).IsRequired();

                entity.Property(e => e.Sdt).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");
            });

            modelBuilder.Entity<DmphongBan>(entity =>
            {
                entity.ToTable("DMPhongBan");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.ChiNhanh)
                    .WithMany(p => p.DmphongBan)
                    .HasForeignKey(d => d.ChiNhanhId)
                    .HasConstraintName("FK_DMPhongBan_IdChiNhanh");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DmphongBan)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DMPhongBan_UserId");
            });

            modelBuilder.Entity<DmsanPham>(entity =>
            {
                entity.ToTable("DMSanPham");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LoaiSpid).HasColumnName("LoaiSPId");

                entity.Property(e => e.MoTa).IsRequired();

                entity.Property(e => e.SeriesNumber).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(200);

                entity.Property(e => e.TenNgan).HasMaxLength(50);

                entity.Property(e => e.ThoiGianDong).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");

                entity.HasOne(d => d.CauHinh)
                    .WithMany(p => p.DmsanPham)
                    .HasForeignKey(d => d.CauHinhId)
                    .HasConstraintName("FK_DMCauHinh_CauHinhId");

                entity.HasOne(d => d.Kho)
                    .WithMany(p => p.DmsanPham)
                    .HasForeignKey(d => d.KhoId)
                    .HasConstraintName("FK_DMSanPham_IdKho");

                entity.HasOne(d => d.LoaiSp)
                    .WithMany(p => p.DmsanPhamLoaiSp)
                    .HasForeignKey(d => d.LoaiSpid)
                    .HasConstraintName("FK_DMSanPham_IdLoaiSP");

                entity.HasOne(d => d.NguoiNhap)
                    .WithMany(p => p.DmsanPham)
                    .HasForeignKey(d => d.NguoiNhapId)
                    .HasConstraintName("FK_DMSanPham_IdNguoiNhap");

                entity.HasOne(d => d.NhaCungCap)
                    .WithMany(p => p.DmsanPham)
                    .HasForeignKey(d => d.NhaCungCapId)
                    .HasConstraintName("FK_DMSanPham_IdNhaCungCap");

                entity.HasOne(d => d.TrangThai)
                    .WithMany(p => p.DmsanPhamTrangThai)
                    .HasForeignKey(d => d.TrangThaiId)
                    .HasConstraintName("FK_DMSanPham_IdTrangThai");
            });

            modelBuilder.Entity<DmtinhThanh>(entity =>
            {
                entity.ToTable("DMTinhThanh");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MoTa).HasMaxLength(200);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.IdLoaiTinhThanhNavigation)
                    .WithMany(p => p.DmtinhThanh)
                    .HasForeignKey(d => d.IdLoaiTinhThanh)
                    .HasConstraintName("FK_DMTinhThanh_IdLoaiTinhThanh");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_DMTinhThanh_ParentId");
            });

            modelBuilder.Entity<Hscmt>(entity =>
            {
                entity.ToTable("HSCmt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NoiDung).IsRequired();

                entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.Hscmt)
                    .HasForeignKey(d => d.IdSanPham)
                    .HasConstraintName("FK_HSCmt_IdSanPham");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Hscmt)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_HSCmt_UserId");
            });

            modelBuilder.Entity<HstinNhan>(entity =>
            {
                entity.ToTable("HSTinNhan");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");

                entity.HasOne(d => d.IdTrangThaiNavigation)
                    .WithMany(p => p.HstinNhan)
                    .HasForeignKey(d => d.IdTrangThai)
                    .HasConstraintName("FK_HSTinNhan_IdTrangThai");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HstinNhan)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_HSTinNhan_UserId");
            });

            modelBuilder.Entity<HstraLoiCmt>(entity =>
            {
                entity.ToTable("HSTraLoiCmt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NoiDung).IsRequired();

                entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");

                entity.HasOne(d => d.IdCmtNavigation)
                    .WithMany(p => p.HstraLoiCmt)
                    .HasForeignKey(d => d.IdCmt)
                    .HasConstraintName("FK_HSTraLoiCmt_IdCmt");
            });

            modelBuilder.Entity<HstraLoiTinNhan>(entity =>
            {
                entity.ToTable("HSTraLoiTinNhan");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NoiDung).IsRequired();

                entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");

                entity.HasOne(d => d.IdTinNhanNavigation)
                    .WithMany(p => p.HstraLoiTinNhan)
                    .HasForeignKey(d => d.IdTinNhan)
                    .HasConstraintName("FK_HSTraLoiTinNhan_IdTinNhan");
            });

            modelBuilder.Entity<Htmenu>(entity =>
            {
                entity.ToTable("HTMenu");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Controller).HasMaxLength(200);

                entity.Property(e => e.Icon).HasMaxLength(200);

                entity.Property(e => e.Link).HasMaxLength(200);

                entity.Property(e => e.Mota).HasMaxLength(200);

                entity.Property(e => e.Ten).HasMaxLength(200);
            });

            modelBuilder.Entity<Htrole>(entity =>
            {
                entity.ToTable("HTRole");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(200);

                entity.Property(e => e.MoTa).HasMaxLength(200);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<HtroleMenu>(entity =>
            {
                entity.ToTable("HTRoleMenu");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Mota).HasMaxLength(200);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.HtroleMenu)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_HTRoleMenu_MenuId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_htrolemenu_parentId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.HtroleMenu)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_HTRoleMenu_RoleId");
            });

            modelBuilder.Entity<Htuser>(entity =>
            {
                entity.ToTable("HTUser");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GioiThieu).HasMaxLength(500);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SoDienThoai).HasMaxLength(50);

                entity.Property(e => e.TenKhongDau).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LoaiTaiKhoan)
                    .WithMany(p => p.Htuser)
                    .HasForeignKey(d => d.LoaiTaiKhoanId)
                    .HasConstraintName("FK_HTUser_LoaiTaiKhoanId");
            });

            modelBuilder.Entity<HtuserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK__HTUserRo__AF2760AD088AEB0C");

                entity.ToTable("HTUserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.HtuserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HTRole_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HtuserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HTRole_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
