using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mission8_Team0101.Migrations
{
    /// <inheritdoc />
    public partial class QuadrantSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Q1 - Urgent & Important" },
                    { 2, "Q2 - Not Urgent & Important" },
                    { 3, "Q3 - Urgent & Not Important" },
                    { 4, "Q4 - Not Urgent & Not Important" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quadrants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quadrants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quadrants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quadrants",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
