using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductStatusSpellingFixDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Featured");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "New");
        }
    }
}
