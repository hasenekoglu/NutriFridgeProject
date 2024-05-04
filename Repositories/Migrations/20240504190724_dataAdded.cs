using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class dataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "FoodValue", "Name", "Recipe" },
                values: new object[,]
                {
                    { 1, "Delicious and nutritious", "Scrambled Eggs", "Scramble eggs and add diced tomatoes" },
                    { 2, "Fresh and healthy", "Tomato Salad", "Slice tomatoes and add olive oil" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "FoodValue", "Name" },
                values: new object[,]
                {
                    { 1, "10g protein", "Egg" },
                    { 2, "100g Vitamin C", "Tomato" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
