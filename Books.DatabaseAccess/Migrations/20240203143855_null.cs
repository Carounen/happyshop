using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class @null : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 2, 3, 18, 38, 54, 824, DateTimeKind.Local).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 2, 3, 18, 38, 54, 824, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 2, 3, 18, 38, 54, 824, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 2, 3, 18, 38, 54, 824, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 3, 18, 38, 54, 824, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 3, 18, 38, 54, 824, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 3, 18, 38, 54, 824, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 3, 18, 38, 54, 824, DateTimeKind.Local).AddTicks(7023));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 2, 3, 16, 6, 55, 989, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 2, 3, 16, 6, 55, 989, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 2, 3, 16, 6, 55, 989, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 2, 3, 16, 6, 55, 989, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 3, 16, 6, 55, 989, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 3, 16, 6, 55, 989, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 3, 16, 6, 55, 989, DateTimeKind.Local).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 3, 16, 6, 55, 989, DateTimeKind.Local).AddTicks(9615));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
