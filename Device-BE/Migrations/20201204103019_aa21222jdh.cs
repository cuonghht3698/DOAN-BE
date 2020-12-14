using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Device_BE.Migrations
{
    public partial class aa21222jdh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CMLoaiTuDien",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaLoai = table.Column<string>(maxLength: 50, nullable: false),
                    Ten = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMLoaiTuDien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DMBaoCao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TieuDe = table.Column<string>(maxLength: 100, nullable: true),
                    NoiDung = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(maxLength: 100, nullable: true),
                    ThuTuc = table.Column<string>(maxLength: 200, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMBaoCao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DMChiNhanh",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(maxLength: 250, nullable: true),
                    Mota = table.Column<string>(maxLength: 250, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 250, nullable: true),
                    UuTien = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMChiNhanh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DMKho",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(maxLength: 200, nullable: true),
                    IdChiNhanh = table.Column<Guid>(nullable: true),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMKho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DMNhaCungCap",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 100, nullable: true),
                    Sdt = table.Column<string>(maxLength: 100, nullable: true),
                    Mota = table.Column<string>(maxLength: 20, nullable: true),
                    Anh = table.Column<string>(maxLength: 1000, nullable: true),
                    Active = table.Column<bool>(maxLength: 250, nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMNhaCungCap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HTMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Icon = table.Column<string>(maxLength: 200, nullable: true),
                    Ten = table.Column<string>(maxLength: 200, nullable: true),
                    Controller = table.Column<string>(maxLength: 200, nullable: true),
                    Link = table.Column<string>(maxLength: 200, nullable: true),
                    MoTa = table.Column<string>(maxLength: 500, nullable: true),
                    IdParent = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HTRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    Ten = table.Column<string>(maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HTUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HoTen = table.Column<string>(maxLength: 100, nullable: true),
                    TenKhongDau = table.Column<string>(maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 100, nullable: true),
                    Tuoi = table.Column<int>(nullable: true),
                    Sdt = table.Column<string>(maxLength: 22, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Username = table.Column<string>(maxLength: 100, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IdAnh = table.Column<Guid>(maxLength: 220, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMTuDien",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaTuDien = table.Column<string>(maxLength: 50, nullable: false),
                    IdLoaiTuDien = table.Column<Guid>(nullable: false),
                    TenNgan = table.Column<string>(maxLength: 50, nullable: true),
                    Ten = table.Column<string>(maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true),
                    UuTien = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMTuDien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CMTuDien_CMLoaiTuDien_IdLoaiTuDien",
                        column: x => x.IdLoaiTuDien,
                        principalTable: "CMLoaiTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HTRoleMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdRole = table.Column<Guid>(nullable: true),
                    IdMenu = table.Column<Guid>(nullable: true),
                    UuTien = table.Column<int>(nullable: true),
                    Mota = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTRoleMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HTRoleMenu_HTMenu_IdMenu",
                        column: x => x.IdMenu,
                        principalTable: "HTMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HTRoleMenu_HTRole_IdRole",
                        column: x => x.IdRole,
                        principalTable: "HTRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DMPhongBan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    IdChiNhanh = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMPhongBan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMPhongBan_DMChiNhanh_IdChiNhanh",
                        column: x => x.IdChiNhanh,
                        principalTable: "DMChiNhanh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMPhongBan_HTUser_UserId",
                        column: x => x.UserId,
                        principalTable: "HTUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HTUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTUserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_HTUserRole_HTRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "HTRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HTUserRole_HTUser_UserId",
                        column: x => x.UserId,
                        principalTable: "HTUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DMAnh",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 250, nullable: false),
                    UuTien = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IdLoaiAnh = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMAnh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMAnh_CMTuDien_IdLoaiAnh",
                        column: x => x.IdLoaiAnh,
                        principalTable: "CMTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DMCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TinNhan = table.Column<string>(maxLength: 1000, nullable: true),
                    TongTien = table.Column<decimal>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true),
                    IdLoaiGD = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    IdTrangThai = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMCart_CMTuDien_IdLoaiGD",
                        column: x => x.IdLoaiGD,
                        principalTable: "CMTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMCart_CMTuDien_IdTrangThai",
                        column: x => x.IdTrangThai,
                        principalTable: "CMTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMCart_HTUser_UserId",
                        column: x => x.UserId,
                        principalTable: "HTUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DMCauHinh",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ManHinh = table.Column<string>(maxLength: 250, nullable: true),
                    CPU = table.Column<string>(maxLength: 250, nullable: true),
                    PIN = table.Column<string>(maxLength: 250, nullable: true),
                    RAM = table.Column<string>(maxLength: 250, nullable: true),
                    NgaySX = table.Column<DateTime>(nullable: true),
                    ThoiGianBaoHanh = table.Column<int>(nullable: true),
                    DungLuong = table.Column<string>(maxLength: 250, nullable: true),
                    MoTa = table.Column<string>(maxLength: 250, nullable: true),
                    IdLoaiCauHinh = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMCauHinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMCauHinh_CMTuDien_IdLoaiCauHinh",
                        column: x => x.IdLoaiCauHinh,
                        principalTable: "CMTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DMDiaChi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    DiaChi = table.Column<string>(maxLength: 100, nullable: false),
                    Sdt = table.Column<string>(maxLength: 100, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IdLoaiDiaChi = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMDiaChi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMDiaChi_CMTuDien_IdLoaiDiaChi",
                        column: x => x.IdLoaiDiaChi,
                        principalTable: "CMTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMDiaChi_HTUser_UserId",
                        column: x => x.UserId,
                        principalTable: "HTUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DMTinhThanh",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(maxLength: 100, nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    UuTien = table.Column<int>(nullable: true),
                    MoTa = table.Column<string>(maxLength: 1000, nullable: true),
                    IdCapTren = table.Column<Guid>(nullable: true),
                    IdLoaiTinhThanh = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMTinhThanh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMTinhThanh_CMTuDien_IdLoaiTinhThanh",
                        column: x => x.IdLoaiTinhThanh,
                        principalTable: "CMTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HSTinNhan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    IdTrangThai = table.Column<Guid>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSTinNhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HSTinNhan_CMTuDien_IdTrangThai",
                        column: x => x.IdTrangThai,
                        principalTable: "CMTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HSTinNhan_HTUser_UserId",
                        column: x => x.UserId,
                        principalTable: "HTUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DMSanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(maxLength: 200, nullable: false),
                    TenNgan = table.Column<string>(maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true),
                    ThoiGianDong = table.Column<DateTime>(nullable: true),
                    SeriesNumber = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    KhuyenMai = table.Column<int>(nullable: true),
                    Gia = table.Column<decimal>(nullable: true),
                    IdCauHinh = table.Column<Guid>(nullable: true),
                    IdTrangThai = table.Column<Guid>(nullable: true),
                    IdNhaCungCap = table.Column<Guid>(nullable: true),
                    IdAnh = table.Column<Guid>(nullable: true),
                    IdNguoiNhap = table.Column<Guid>(nullable: true),
                    IdKho = table.Column<Guid>(nullable: true),
                    IdLoaiSP = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMSanPham_DMAnh_IdAnh",
                        column: x => x.IdAnh,
                        principalTable: "DMAnh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMSanPham_DMCauHinh_IdCauHinh",
                        column: x => x.IdCauHinh,
                        principalTable: "DMCauHinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMSanPham_DMKho_IdKho",
                        column: x => x.IdKho,
                        principalTable: "DMKho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMSanPham_CMTuDien_IdLoaiSP",
                        column: x => x.IdLoaiSP,
                        principalTable: "CMTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMSanPham_HTUser_IdNguoiNhap",
                        column: x => x.IdNguoiNhap,
                        principalTable: "HTUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMSanPham_DMNhaCungCap_IdNhaCungCap",
                        column: x => x.IdNhaCungCap,
                        principalTable: "DMNhaCungCap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DMSanPham_CMTuDien_IdTrangThai",
                        column: x => x.IdTrangThai,
                        principalTable: "CMTuDien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HSTraLoiTinNhan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTinNhan = table.Column<Guid>(nullable: true),
                    NoiDung = table.Column<string>(maxLength: 500, nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true),
                    Watched = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSTraLoiTinNhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HSTraLoiTinNhan_HSTinNhan_IdTinNhan",
                        column: x => x.IdTinNhan,
                        principalTable: "HSTinNhan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DMCartDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdSanPham = table.Column<Guid>(nullable: true),
                    UuTien = table.Column<int>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMCartDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMCartDetail_DMSanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "DMSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HSCmt",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    IdSanPham = table.Column<Guid>(nullable: true),
                    NoiDung = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSCmt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HSCmt_DMSanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "DMSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HSCmt_HTUser_UserId",
                        column: x => x.UserId,
                        principalTable: "HTUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HSTraLoiCmt",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCmt = table.Column<Guid>(nullable: true),
                    NoiDung = table.Column<string>(maxLength: 220, nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSTraLoiCmt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HSTraLoiCmt_HSCmt_IdCmt",
                        column: x => x.IdCmt,
                        principalTable: "HSCmt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "HTRole",
                columns: new[] { "Id", "Code", "MoTa", "Ten" },
                values: new object[,]
                {
                    { new Guid("9b76ed13-ce77-4d41-0908-08d8223497a3"), "giamdoc", "GIAMDOC", "Giám Đốc" },
                    { new Guid("9b76ed13-ce77-4d41-0908-08d5423497a3"), "admin", "ADMIN", "admin" },
                    { new Guid("9b76ed13-ce77-4d41-0908-08d8123497a3"), "admin", "ADMIN", "Nhân viên" },
                    { new Guid("9b76ed13-ce77-4d41-0908-08d8223497a8"), "khachhang", "Khách hàng", "Khách hàng" }
                });

            migrationBuilder.InsertData(
                table: "HTUser",
                columns: new[] { "Id", "Active", "CreateDate", "DiaChi", "Email", "HoTen", "IdAnh", "PasswordHash", "Sdt", "TenKhongDau", "Tuoi", "Username" },
                values: new object[] { new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"), true, new DateTime(2020, 12, 4, 17, 30, 19, 356, DateTimeKind.Local).AddTicks(2974), "Hà Nội", "cuong@gmail.com", "ad CườngNB", null, "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", null, "nbc", 22, "admin" });

            migrationBuilder.InsertData(
                table: "HTUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9b76ed13-ce77-4d41-0908-08d5423497a3"), new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3") });

            migrationBuilder.CreateIndex(
                name: "IX_CMTuDien_IdLoaiTuDien",
                table: "CMTuDien",
                column: "IdLoaiTuDien");

            migrationBuilder.CreateIndex(
                name: "IX_DMAnh_IdLoaiAnh",
                table: "DMAnh",
                column: "IdLoaiAnh");

            migrationBuilder.CreateIndex(
                name: "IX_DMCart_IdLoaiGD",
                table: "DMCart",
                column: "IdLoaiGD");

            migrationBuilder.CreateIndex(
                name: "IX_DMCart_IdTrangThai",
                table: "DMCart",
                column: "IdTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_DMCart_UserId",
                table: "DMCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DMCartDetail_IdSanPham",
                table: "DMCartDetail",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DMCauHinh_IdLoaiCauHinh",
                table: "DMCauHinh",
                column: "IdLoaiCauHinh");

            migrationBuilder.CreateIndex(
                name: "IX_DMDiaChi_IdLoaiDiaChi",
                table: "DMDiaChi",
                column: "IdLoaiDiaChi");

            migrationBuilder.CreateIndex(
                name: "IX_DMDiaChi_UserId",
                table: "DMDiaChi",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DMPhongBan_IdChiNhanh",
                table: "DMPhongBan",
                column: "IdChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_DMPhongBan_UserId",
                table: "DMPhongBan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DMSanPham_IdAnh",
                table: "DMSanPham",
                column: "IdAnh");

            migrationBuilder.CreateIndex(
                name: "IX_DMSanPham_IdCauHinh",
                table: "DMSanPham",
                column: "IdCauHinh");

            migrationBuilder.CreateIndex(
                name: "IX_DMSanPham_IdKho",
                table: "DMSanPham",
                column: "IdKho");

            migrationBuilder.CreateIndex(
                name: "IX_DMSanPham_IdLoaiSP",
                table: "DMSanPham",
                column: "IdLoaiSP");

            migrationBuilder.CreateIndex(
                name: "IX_DMSanPham_IdNguoiNhap",
                table: "DMSanPham",
                column: "IdNguoiNhap");

            migrationBuilder.CreateIndex(
                name: "IX_DMSanPham_IdNhaCungCap",
                table: "DMSanPham",
                column: "IdNhaCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_DMSanPham_IdTrangThai",
                table: "DMSanPham",
                column: "IdTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_DMTinhThanh_IdLoaiTinhThanh",
                table: "DMTinhThanh",
                column: "IdLoaiTinhThanh");

            migrationBuilder.CreateIndex(
                name: "IX_HSCmt_IdSanPham",
                table: "HSCmt",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_HSCmt_UserId",
                table: "HSCmt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HSTinNhan_IdTrangThai",
                table: "HSTinNhan",
                column: "IdTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_HSTinNhan_UserId",
                table: "HSTinNhan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HSTraLoiCmt_IdCmt",
                table: "HSTraLoiCmt",
                column: "IdCmt");

            migrationBuilder.CreateIndex(
                name: "IX_HSTraLoiTinNhan_IdTinNhan",
                table: "HSTraLoiTinNhan",
                column: "IdTinNhan");

            migrationBuilder.CreateIndex(
                name: "IX_HTRoleMenu_IdMenu",
                table: "HTRoleMenu",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_HTRoleMenu_IdRole",
                table: "HTRoleMenu",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_HTUserRole_UserId",
                table: "HTUserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMBaoCao");

            migrationBuilder.DropTable(
                name: "DMCart");

            migrationBuilder.DropTable(
                name: "DMCartDetail");

            migrationBuilder.DropTable(
                name: "DMDiaChi");

            migrationBuilder.DropTable(
                name: "DMPhongBan");

            migrationBuilder.DropTable(
                name: "DMTinhThanh");

            migrationBuilder.DropTable(
                name: "HSTraLoiCmt");

            migrationBuilder.DropTable(
                name: "HSTraLoiTinNhan");

            migrationBuilder.DropTable(
                name: "HTRoleMenu");

            migrationBuilder.DropTable(
                name: "HTUserRole");

            migrationBuilder.DropTable(
                name: "DMChiNhanh");

            migrationBuilder.DropTable(
                name: "HSCmt");

            migrationBuilder.DropTable(
                name: "HSTinNhan");

            migrationBuilder.DropTable(
                name: "HTMenu");

            migrationBuilder.DropTable(
                name: "HTRole");

            migrationBuilder.DropTable(
                name: "DMSanPham");

            migrationBuilder.DropTable(
                name: "DMAnh");

            migrationBuilder.DropTable(
                name: "DMCauHinh");

            migrationBuilder.DropTable(
                name: "DMKho");

            migrationBuilder.DropTable(
                name: "HTUser");

            migrationBuilder.DropTable(
                name: "DMNhaCungCap");

            migrationBuilder.DropTable(
                name: "CMTuDien");

            migrationBuilder.DropTable(
                name: "CMLoaiTuDien");
        }
    }
}
