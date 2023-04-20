using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductRatingToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductRating_ProductRatingId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRating",
                table: "ProductRating");

            migrationBuilder.RenameTable(
                name: "ProductRating",
                newName: "ProductRatings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRatings",
                table: "ProductRatings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductRatings_ProductRatingId",
                table: "Products",
                column: "ProductRatingId",
                principalTable: "ProductRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductRatings_ProductRatingId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRatings",
                table: "ProductRatings");

            migrationBuilder.RenameTable(
                name: "ProductRatings",
                newName: "ProductRating");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRating",
                table: "ProductRating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductRating_ProductRatingId",
                table: "Products",
                column: "ProductRatingId",
                principalTable: "ProductRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
