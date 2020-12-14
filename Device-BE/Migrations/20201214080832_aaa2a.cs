using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Device_BE.Migrations
{
    public partial class aaa2a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CMTuDien_CMLoaiTuDien_LoaiTuDienId",
                table: "CMTuDien");

            migrationBuilder.AlterColumn<Guid>(
                name: "LoaiTuDienId",
                table: "CMTuDien",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497a3"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 15, 8, 31, 915, DateTimeKind.Local).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "HTUser",
                keyColumn: "Id",
                keyValue: new Guid("9b76ed13-ce77-4d41-0908-08d0223497b2"),
                column: "CreateDate",
                value: new DateTime(2020, 12, 14, 15, 8, 31, 916, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.AddForeignKey(
                name: "FK_CMTuDien_CMLoaiTuDien_LoaiTuDienId",
                table: "CMTuDien",
                column: "LoaiTuDienId",
                principalTable: "CMLoaiTuDien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CMTuDien_CMLoaiTuDien_LoaiTuDienId",
                table: "CMTuDien");

            migrationBuilder.AlterColumn<Guid>(
                name: "LoaiTuDienId",
                table: "CMTuDien",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CMTuDien_CMLoaiTuDien_LoaiTuDienId",
                table: "CMTuDien",
                column: "LoaiTuDienId",
                principalTable: "CMLoaiTuDien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
