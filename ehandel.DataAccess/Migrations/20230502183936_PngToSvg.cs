using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PngToSvg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-02 20:39", "\\img\\products\\placeholder.svg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-02 20:37", "\\img\\products\\placeholder.png" });
        }
    }
}
