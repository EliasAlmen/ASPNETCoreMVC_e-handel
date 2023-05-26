using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class productImagesAddedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 16, 9, 7, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 16, 9, 7, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 16, 9, 7, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 16, 9, 7, DateTimeKind.Local).AddTicks(636));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 16, 9, 7, DateTimeKind.Local).AddTicks(640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: "2023-05-26 13:16");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:16", "\\img\\products\\i-m__prakhar-kont-AgU9-qsNc1Y-unsplash.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:16", "\\img\\products\\artin-bakhan-SqLyNHbsLKQ-unsplash.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:16", "\\img\\products\\omar-prestwich-mBjrF0MK6mc-unsplash.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:16", "\\img\\products\\allen-taylor-lLk1oJA7Wkg-unsplash.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:16", "\\img\\products\\laura-adai-lJHhM4D0wCU-unsplash.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:16", "\\img\\products\\katherine-chase-VNBUJ6imfGs-unsplash.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:16", "\\img\\products\\engin-akyurt-6k5cGTWluTs-unsplash.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 5, 33, 260, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 5, 33, 260, DateTimeKind.Local).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 5, 33, 260, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 5, 33, 260, DateTimeKind.Local).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 26, 13, 5, 33, 260, DateTimeKind.Local).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: "2023-05-26 13:05");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:05", "\\img\\placeholders\\270x295.svg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:05", "\\img\\placeholders\\270x295.svg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:05", "\\img\\placeholders\\270x295.svg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:05", "\\img\\placeholders\\270x295.svg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:05", "\\img\\placeholders\\270x295.svg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:05", "\\img\\placeholders\\270x295.svg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:05", "\\img\\placeholders\\270x295.svg" });
        }
    }
}
