using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductRatingToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Five",
                table: "ProductRatings");

            migrationBuilder.DropColumn(
                name: "Four",
                table: "ProductRatings");

            migrationBuilder.DropColumn(
                name: "One",
                table: "ProductRatings");

            migrationBuilder.DropColumn(
                name: "Three",
                table: "ProductRatings");

            migrationBuilder.DropColumn(
                name: "Two",
                table: "ProductRatings");

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "ProductRatings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ProductRatings");

            migrationBuilder.AddColumn<int>(
                name: "Five",
                table: "ProductRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Four",
                table: "ProductRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "One",
                table: "ProductRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Three",
                table: "ProductRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Two",
                table: "ProductRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
