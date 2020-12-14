using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Device_BE.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                columns: new[] { "CreateDate", "GioiThieu" },
                values: new object[] { new DateTime(2020, 12, 14, 21, 33, 48, 472, DateTimeKind.Local).AddTicks(3836), "Hello world Im Iron Man" });

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"),
                columns: new[] { "CreateDate", "GioiThieu" },
                values: new object[] { new DateTime(2020, 12, 14, 21, 33, 48, 473, DateTimeKind.Local).AddTicks(2321), "Xin chào hihi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                columns: new[] { "CreateDate", "GioiThieu" },
                values: new object[] { new DateTime(2020, 12, 14, 21, 32, 2, 689, DateTimeKind.Local).AddTicks(5723), null });

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"),
                columns: new[] { "CreateDate", "GioiThieu" },
                values: new object[] { new DateTime(2020, 12, 14, 21, 32, 2, 690, DateTimeKind.Local).AddTicks(4268), null });
        }
    }
}
