using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AlotOfFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ApplicationUserCompany_ApplicationUserCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCompany",
                table: "ApplicationUserCompany");

            migrationBuilder.RenameTable(
                name: "ApplicationUserCompany",
                newName: "ApplicationUserCompanies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCompanies",
                table: "ApplicationUserCompanies",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeOfContact",
                value: new DateTime(2023, 5, 17, 13, 46, 53, 588, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: "2023-05-17 13:46");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ApplicationUserCompanies_ApplicationUserCompanyId",
                table: "AspNetUsers",
                column: "ApplicationUserCompanyId",
                principalTable: "ApplicationUserCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ApplicationUserCompanies_ApplicationUserCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCompanies",
                table: "ApplicationUserCompanies");

            migrationBuilder.RenameTable(
                name: "ApplicationUserCompanies",
                newName: "ApplicationUserCompany");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCompany",
                table: "ApplicationUserCompany",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ApplicationUserCompany_ApplicationUserCompanyId",
                table: "AspNetUsers",
                column: "ApplicationUserCompanyId",
                principalTable: "ApplicationUserCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
