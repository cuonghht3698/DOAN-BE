using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Device_BE.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GioiThieu",
                table: "HTUser",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 21, 32, 2, 689, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 21, 32, 2, 690, DateTimeKind.Local).AddTicks(4268));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GioiThieu",
                table: "HTUser");

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 21, 27, 56, 179, DateTimeKind.Local).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 21, 27, 56, 180, DateTimeKind.Local).AddTicks(2533));
        }
    }
}
