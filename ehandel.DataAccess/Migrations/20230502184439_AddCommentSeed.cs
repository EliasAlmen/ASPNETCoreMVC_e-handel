using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ehandel.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactUs",
                columns: new[] { "Id", "Comment", "Company", "Email", "Name", "Phone", "TimeOfContact" },
                values: new object[] { 1, "This is a test comment.", "Acme Inc.", "johndoe@example.com", "John Doe", "123-456-7890", new DateTime(2023, 5, 2, 20, 44, 38, 954, DateTimeKind.Local).AddTicks(9502) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: "2023-05-02 20:44");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: "2023-05-02 20:39");
        }
    }
}
