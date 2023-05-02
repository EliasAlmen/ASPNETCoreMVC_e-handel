using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeededItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Table lamp" },
                    { 2, "Light" },
                    { 3, "Bags" },
                    { 4, "Dress" },
                    { 5, "Decoration" },
                    { 6, "Essentials" },
                    { 7, "Interior" },
                    { 8, "Laptop" },
                    { 9, "Mobile" },
                    { 10, "Beauty" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "ImageUrl", "Name", "Price", "ProductRatingId", "ProductStatusId", "SKU" },
                values: new object[] { 1, 1, "2023-05-02 20:37", "Placeholder description", "\\img\\products\\placeholder.png", "Placeholder product", 99.99m, 1, 1, "04acc686-02ca-4e4a-adc1-cb6bb3f297c4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
