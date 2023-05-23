using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ApplicationUserCompany",
                newName: "CompanyName");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 17, 9, 17, 10, 365, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: "2023-05-17 09:17");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "ApplicationUserCompany",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 17, 9, 15, 49, 32, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: "2023-05-17 09:15");
        }
    }
}
