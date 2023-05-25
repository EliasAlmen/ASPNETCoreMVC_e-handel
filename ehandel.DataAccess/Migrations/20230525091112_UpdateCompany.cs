using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 11, 12, 503, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 11, 12, 503, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 11, 12, 503, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 11, 12, 503, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 25, 11, 11, 12, 503, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: "2023-05-25 11:11");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: "2023-05-25 11:11");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: "2023-05-25 11:11");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: "2023-05-25 11:11");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: "2023-05-25 11:11");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: "2023-05-25 11:11");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: "2023-05-25 11:11");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: "2023-05-25 11:11");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 24, 13, 40, 30, 66, DateTimeKind.Local).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 24, 13, 40, 30, 66, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 24, 13, 40, 30, 66, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 4,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 24, 13, 40, 30, 66, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 5,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 24, 13, 40, 30, 67, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: "2023-05-24 13:40");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: "2023-05-24 13:40");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: "2023-05-24 13:40");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: "2023-05-24 13:40");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: "2023-05-24 13:40");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: "2023-05-24 13:40");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: "2023-05-24 13:40");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: "2023-05-24 13:40");
        }
    }
}
