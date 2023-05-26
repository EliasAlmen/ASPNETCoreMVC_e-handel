using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class finalmiggie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-26 13:05", "\\img\\products\\mateo-abrahan-vVmfi-yhCsc-unsplash.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: "2023-05-26 13:05");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: "2023-05-26 13:05");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: "2023-05-26 13:05");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: "2023-05-26 13:05");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: "2023-05-26 13:05");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: "2023-05-26 13:05");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: "2023-05-26 13:05");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 13, 16, 912, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 13, 16, 912, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 13, 16, 912, DateTimeKind.Local).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 13, 16, 912, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 13, 16, 912, DateTimeKind.Local).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "ImageUrl" },
                values: new object[] { "2023-05-25 11:13", "\\img\\placeholders\\270x295.svg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: "2023-05-25 11:13");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: "2023-05-25 11:13");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: "2023-05-25 11:13");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: "2023-05-25 11:13");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: "2023-05-25 11:13");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: "2023-05-25 11:13");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: "2023-05-25 11:13");
        }
    }
}
