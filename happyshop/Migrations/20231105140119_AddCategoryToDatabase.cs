using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace happyshop.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDateTime", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 5, 18, 1, 19, 441, DateTimeKind.Local).AddTicks(3183), 1, "Tech" },
                    { 2, new DateTime(2023, 11, 5, 18, 1, 19, 441, DateTimeKind.Local).AddTicks(3200), 2, "wood" },
                    { 3, new DateTime(2023, 11, 5, 18, 1, 19, 441, DateTimeKind.Local).AddTicks(3201), 3, "interior" },
                    { 4, new DateTime(2023, 11, 5, 18, 1, 19, 441, DateTimeKind.Local).AddTicks(3203), 4, "extrior" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
