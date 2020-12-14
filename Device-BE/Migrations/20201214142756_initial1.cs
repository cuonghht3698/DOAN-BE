using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Device_BE.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAnh",
                table: "HTUser");

            migrationBuilder.AddColumn<Guid>(
                name: "AnhId",
                table: "HTUser",
                maxLength: 220,
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_HTUser_AnhId",
                table: "HTUser",
                column: "AnhId");

            migrationBuilder.AddForeignKey(
                name: "FK_HTUser_DMAnh_AnhId",
                table: "HTUser",
                column: "AnhId",
                principalTable: "DMAnh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HTUser_DMAnh_AnhId",
                table: "HTUser");

            migrationBuilder.DropIndex(
                name: "IX_HTUser_AnhId",
                table: "HTUser");

            migrationBuilder.DropColumn(
                name: "AnhId",
                table: "HTUser");

            migrationBuilder.AddColumn<Guid>(
                name: "IdAnh",
                table: "HTUser",
                type: "uniqueidentifier",
                maxLength: 220,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 20, 53, 5, 120, DateTimeKind.Local).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 20, 53, 5, 121, DateTimeKind.Local).AddTicks(5795));
        }
    }
}
