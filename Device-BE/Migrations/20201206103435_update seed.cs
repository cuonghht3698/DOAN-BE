using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Device_BE.Migrations
{
    public partial class updateseed : Migration 
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HTRole",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d8123497a3"),
                column: "Code",
                value: "nhanvien");

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 34, 35, 293, DateTimeKind.Local).AddTicks(6487));

            migrationBuilder.InsertData(
                table: "HTUser",
                columns: new[] { "Id", "Active", "CreateDate", "DiaChi", "Email", "HoTen", "IdAnh", "PasswordHash", "Sdt", "TenKhongDau", "Tuoi", "Username" },
                values: new object[] { new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"), true, new DateTime(2020, 12, 6, 17, 34, 35, 294, DateTimeKind.Local).AddTicks(7096), "Hà Nội", "cuong@gmail.com", "KH", null, "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", null, "nbc", 22, "cuong" });

            migrationBuilder.InsertData(
                table: "HTUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9b76ed13-ce77-4d41-0908-08d8223497a8"), new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HTUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9b76ed13-ce77-4d41-0908-08d8223497a8"), new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2") });

            migrationBuilder.DeleteData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"));

            migrationBuilder.UpdateData(
                table: "HTRole",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d8123497a3"),
                column: "Code",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 4, 17, 30, 19, 356, DateTimeKind.Local).AddTicks(2974));
        }
    }
}
