using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Device_BE.Migrations
{
    public partial class aaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CMTuDien_CMLoaiTuDien_IdLoaiTuDien",
                table: "CMTuDien");

            migrationBuilder.DropIndex(
                name: "IX_CMTuDien_IdLoaiTuDien",
                table: "CMTuDien");

            migrationBuilder.DropColumn(
                name: "IdLoaiTuDien",
                table: "CMTuDien");

            migrationBuilder.AddColumn<Guid>(
                name: "LoaiTuDienId",
                table: "CMTuDien",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 14, 46, 24, 725, DateTimeKind.Local).AddTicks(6899));

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 14, 46, 24, 726, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.CreateIndex(
                name: "IX_CMTuDien_LoaiTuDienId",
                table: "CMTuDien",
                column: "LoaiTuDienId");

            migrationBuilder.AddForeignKey(
                name: "FK_CMTuDien_CMLoaiTuDien_LoaiTuDienId",
                table: "CMTuDien",
                column: "LoaiTuDienId",
                principalTable: "CMLoaiTuDien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CMTuDien_CMLoaiTuDien_LoaiTuDienId",
                table: "CMTuDien");

            migrationBuilder.DropIndex(
                name: "IX_CMTuDien_LoaiTuDienId",
                table: "CMTuDien");

            migrationBuilder.DropColumn(
                name: "LoaiTuDienId",
                table: "CMTuDien");

            migrationBuilder.AddColumn<Guid>(
                name: "IdLoaiTuDien",
                table: "CMTuDien",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 34, 35, 293, DateTimeKind.Local).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 6, 17, 34, 35, 294, DateTimeKind.Local).AddTicks(7096));

            migrationBuilder.CreateIndex(
                name: "IX_CMTuDien_IdLoaiTuDien",
                table: "CMTuDien",
                column: "IdLoaiTuDien");

            migrationBuilder.AddForeignKey(
                name: "FK_CMTuDien_CMLoaiTuDien_IdLoaiTuDien",
                table: "CMTuDien",
                column: "IdLoaiTuDien",
                principalTable: "CMLoaiTuDien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
